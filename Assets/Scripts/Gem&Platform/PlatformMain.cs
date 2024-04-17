using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMain : MonoBehaviour
{
    public List<Platform> platforms;
    public float UpperLimit, LowerLimit;
    private void Start()
    {
        ActiveRandomPlatform();
    }
    private void Update()
    {
        foreach (Platform platform in platforms) 
        {
            if (platform.reset)
            {
                ResetPlatform(platform);
            } 
        }

    }
    public void ResetPlatform(Platform platform)
    {
        float randomLimit = Random.Range(LowerLimit, UpperLimit);
        platform.transform.localPosition = new Vector3(platform._startPos.x, randomLimit, 0);
        platform.reset = false;
        platform.gameObject.SetActive(false);
        int random = Random.Range(0, platforms.Count);
        platforms[random].gameObject.SetActive(true);
    }
    void ActiveRandomPlatform()
    {
        int random = Random.Range(0, platforms.Count);
        platforms[random].gameObject.SetActive(true);
    }
}
