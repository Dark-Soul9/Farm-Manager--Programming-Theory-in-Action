using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : Food
{
    protected override void Init()
    {
        hungerAmount = 70f;
        sellValue = 400;
        growthRate = 100f;
        seedAmount = 2;
        foodType = 2;
        canEat = false;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
