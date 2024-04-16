using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsMovement : MonoBehaviour
{
    private Transform _startPos;
    public Transform limit;
    public float Speed;

    private void Start()
    {
        _startPos = transform;
    }
    private void Update()
    {

        if(transform.position.x <= limit.position.x)
        {
            transform.position = new Vector3(0.07f, 0f, 0f);
        }
        else
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
    }
}
