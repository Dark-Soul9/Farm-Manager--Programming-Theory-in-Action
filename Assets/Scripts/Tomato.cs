using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Food//Inheritence
{
    //polymorphism
    protected override void Init()
    {
        hungerAmount = 25f;
        sellValue = 150;
    }

    
}
