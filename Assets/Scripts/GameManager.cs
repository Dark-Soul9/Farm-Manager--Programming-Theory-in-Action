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
    private float timeElapsed = 0.5f;
    private float timeInterval = 0.5f;
    public bool IsGameOver = false;
    
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
            if (value > 70)
            {
                hunger = 100;
            }
            else
            {
                hunger += value;
            }
        }
    }
    private void Awake()
    {
        if (Instance != null)
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
    private void Update()
    {
        if (!IsGameOver)
        {
            if (timeElapsed > Time.deltaTime)
            {
                timeElapsed -= Time.deltaTime;
            }
            else
            {
                DeductHunger();
                timeElapsed = timeInterval;
            }
        }
    }
    //public void FoodUpdate(int foodType)
    //{
    //    switch (foodType)
    //    {
    //        case 0:
    //            foodAmount[0]++;
    //            break;
    //        case 1:
    //            foodAmount[1]++;
    //            break;
    //        case 2:
    //            foodAmount[2]++;
    //            break;
    //        default:
    //            //do nothing
    //            break;
    //    }
    //}
    public void UpdateHunger(float hungerAmount)
    {
        if((hunger+hungerAmount) > 100)
        {
            hunger = 100;
            cropsEaten++;
        }
        else
        {
            hunger += hungerAmount;
            cropsEaten++;
        }
    }

    public void UpdateCash(int cashAmount)
    {
        cash += cashAmount;
        if(cashAmount<0)
        {
            return;
        }
        cropsSold++;
    }

    private void GameOver()
    {
        IsGameOver = true;
        cropsEaten = 0;
        cropsSold = 0;
        hunger = 100f;
        cash = 500;
    }

    private void DeductHunger()
    {
        hunger -= 1f;
        if(hunger < 1)
        {
            GameOver();
        }
    }
}
