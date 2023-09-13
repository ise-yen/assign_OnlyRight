using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = -5;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
