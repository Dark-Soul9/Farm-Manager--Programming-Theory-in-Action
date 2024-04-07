using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : Food
{
    // Start is called before the first frame update
    private void Start()
    {
        Init();
    }
    protected override void Init()
    {
        hungerAmount = 10f;
        sellValue = 50;
        growthRate = 30f;
        seedAmount = 4;
        foodType = 0;
    }

    private void Update()
    {
        
    }

}
