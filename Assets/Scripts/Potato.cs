using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : Food
{
    
    private void Start()
    {
        Init();
    }
    protected override void Init()
    {
        hungerAmount = 10f;
        sellValue = 50;
        growthRate = 10f;
        seedAmount = 4;
        foodType = 0;
        canEat = false;
    }


    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
