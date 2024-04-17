using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public List<Hearths> hearths;

    public bool HearthsClose()
    {
        for (int i = 0; i < hearths.Count; i++)
        {
            if (hearths[i].isActive)
            {
                hearths[i].isActive = false;
                hearths[i].gameObject.GetComponent<Image>().enabled = false;
                return false;
            }
            
        }
        return true;
    }
}
