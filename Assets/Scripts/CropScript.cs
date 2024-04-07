using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropScript : MonoBehaviour
{
    [SerializeField] private int cropType; // 0 for potato, 1 for tomato, 2 for watermelon
    private void OnMouseDown()
    {
        //send info to food class
    }

    public void GetCropType(int crop)
    {
        cropType = crop;
    }
}
