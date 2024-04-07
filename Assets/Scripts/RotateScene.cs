using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScene : MonoBehaviour
{
    private float horizontalInput;
    private float rotationSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed * horizontalInput);
    }
}
