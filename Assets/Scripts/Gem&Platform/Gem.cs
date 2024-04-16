using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectiable
{
    public void Collect()
    {
        GameManager.Instance.Score += 1;
        GameManager.Instance.Speed += 0.1f;
        gameObject.SetActive(false);
    }
}
