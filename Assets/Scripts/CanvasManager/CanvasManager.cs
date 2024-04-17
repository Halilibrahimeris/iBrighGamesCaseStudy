using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class CanvasManager : MonoBehaviour
{
    public AudioMixer mixer;
    public void ActiveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void OnValueChange(float value)
    {
        mixer.SetFloat("MasterVolume", value);
    }
}
