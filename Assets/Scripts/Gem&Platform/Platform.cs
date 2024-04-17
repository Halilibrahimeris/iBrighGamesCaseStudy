using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 _startPos;
    public Transform limit;
    public Gem[] gems;
    public bool reset;
    private void Start()
    {
        _startPos = transform.position;
        gems = GetComponentsInChildren<Gem>();
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (transform.position.x <= limit.position.x)
        {
            reset = true;
            ActiveGems();
        }
        else
        {
            transform.position += Vector3.left * GameManager.Instance.Speed * Time.deltaTime;
        }
    }
    void ActiveGems()
    {
        for (int i = 0; i < gems.Length; i++) 
        {
            gems[i].gameObject.SetActive(true);
        }
    }
}
