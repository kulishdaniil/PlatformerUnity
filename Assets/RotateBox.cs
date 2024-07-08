using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBox : MonoBehaviour
{
    public float rotateSpeed = 2f;
    public float UpDownSpeed = 2f;
    private float TranslateY = 0.07f;
    private int count = 0;

    void Update()
    {
        count++;
        gameObject.transform.Rotate(new Vector3(0, 5, 0) * rotateSpeed * Time.deltaTime);
        gameObject.transform.Translate(new Vector3(0, TranslateY, 0) * UpDownSpeed * Time.deltaTime);
        if (count==100)
        {
            TranslateY = -TranslateY;
            count = 0;
        }
    }
}
