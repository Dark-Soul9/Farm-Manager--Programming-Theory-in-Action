using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Food
{
    protected override void Init()
    {
        hungerAmount = 25f;
        sellValue = 150;
        growthRate = 40f;
        seedAmount = 3;
        foodType = 1;
        canEat = false;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
