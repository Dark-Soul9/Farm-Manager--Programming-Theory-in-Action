using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float hunger;
    private int cash = 500;
    private int[] foodAmount;
    [SerializeField] private int cropsSold;
    [SerializeField] private int cropsEaten;

    public int Cash
    {
        get { return cash; }
        set
        {
            if(value < 0)
            {
                Debug.LogError("You can't be in negative cash");
            }
            else
            {
                cash = value;
            }
        }
    }

    public float Hunger
    {
        get { return hunger; }
        set 
        { 
            if (hunger + value > 100)
            {
                Debug.LogError("You cant set value greater than stomach");
            }
            else
            {
                hunger += value;
            }
        }
    }

    public void FoodUpdate(int foodType)
    {
        switch(foodType)
        {
            case 0:
                foodAmount[0]++;
                break;
            case 1:
                foodAmount[1]++;
                break;
            case 2:
                foodAmount[2]++;
                break;
            default:
                //do nothing
                break;
        }
    }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        hunger = 100f;
        cash = 500;
    }
    public void UpdateHunger(float hungerAmount)
    {
        if(hunger+hungerAmount !> 100)
        {
            hunger += hungerAmount;
            cropsEaten++;
        }
        else
        {
            Debug.Log("Full");
        }
    }

    public void UpdateCash(int cashAmount)
    {
        cash += cashAmount;
        cropsSold++;
    }
}
