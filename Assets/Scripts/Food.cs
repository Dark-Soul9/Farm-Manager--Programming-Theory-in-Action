using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    protected float hungerAmount;
    protected int sellValue;
    protected float growthRate;
    protected int seedAmount;
    protected bool isGrown;
    protected int foodType;

    protected virtual void Init()
    {

    }
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        
    }

    protected void OnClick()
    {
        if(isGrown)
        {
            //collect
        }
    }
    protected void GiveHunger()
    {

    }

    protected void GiveMoney()
    {

    }

    protected void StartGrowing()
    {

    }
}
