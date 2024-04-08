using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : Food //Inheritence
{
    //Polymorphism
    protected override void Init()
    {
        hungerAmount = 10f;
        sellValue = 50;
    }

}
