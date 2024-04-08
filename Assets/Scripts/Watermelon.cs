using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : Food //Inheritence;
{
    //Polymorphism
    protected override void Init()
    {
        hungerAmount = 70f;
        sellValue = 400;
    }

    
}
