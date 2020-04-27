using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    Vector3 startPosition;
    public float speed;
    
    void Start()
    {
        startPosition = transform.position;
    }

    
    void Update()
    {
        float move = Mathf.Repeat(Time.time * speed, 80);
        transform.position = startPosition + Vector3.back * move;
    }
}
