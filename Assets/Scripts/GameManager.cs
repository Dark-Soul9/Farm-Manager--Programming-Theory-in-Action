using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float hunger;
    private int cash = 500;
    private float timeElapsed = 0.5f;
    private float timeInterval = 0.5f;
    public bool IsGameOver = false;
    
    //Encapsulation
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
    //Encapsulation
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
    
    public void UpdateHunger(float hungerAmount)
    {
        if((hunger+hungerAmount) > 100)
        {
            hunger = 100;
        }
        else
        {
            hunger += hungerAmount;
        }
    }

    public void UpdateCash(int cashAmount)
    {
        cash += cashAmount;
        if(cashAmount<0)
        {
            return;
        }
    }

    private void GameOver()
    {
        IsGameOver = true;
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
