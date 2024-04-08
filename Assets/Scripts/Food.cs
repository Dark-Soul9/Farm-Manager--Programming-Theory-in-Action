using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    protected GameUI gameUI;
    protected float hungerAmount;
    protected int sellValue;

    protected abstract void Init();

    
    private void Start()
    {
        Init();
        gameUI = GameObject.Find("Canvas").GetComponent<GameUI>();
    }
    private void Update()
    {
        
    }

    protected void OnMouseDown()
    {
        if(!GameManager.Instance.IsGameOver)
        {
            gameUI.GetInfo(hungerAmount, sellValue);
            Destroy(gameObject);
        }
    }

}
