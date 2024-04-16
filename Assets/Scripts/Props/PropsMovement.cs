using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsMovement : MonoBehaviour
{
    private Vector3 _startPos;
    public Transform limit;
    public float Speed;
    public bool Restart;
    private void Start()
    {
        _startPos = transform.position;
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (transform.position.x <= limit.position.x)
        {
            transform.position = _startPos;
            Restart = true;
        }
        else
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
            Restart = false;
        }
    }
}
