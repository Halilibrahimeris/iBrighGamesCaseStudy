using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.TryGetComponent<ICollectiable>(out ICollectiable collect))
        {
            collect.Collect();
        }
    }
}
