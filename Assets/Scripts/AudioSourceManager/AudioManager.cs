using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> clipList = new List<AudioClip>();
    private AudioSource audioSource;
    private int _clipId;
    private int _nextclipId;
    public bool nextSong = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _clipId = Random.Range(0, clipList.Count);
        audioSource.clip = clipList[_clipId];
    }

    private void Update()
    {
        isClipOver();
    }

    public void isClipOver()
    {
        if(audioSource.isPlaying == false || nextSong) 
        {
            _nextclipId = Random.Range(0,clipList.Count);
            while(_nextclipId == _clipId) 
            {
                _nextclipId = Random.Range(0, clipList.Count);
            }
            _clipId = _nextclipId;
            audioSource.clip = clipList[_clipId];
            audioSource.Play();
            nextSong = false;
        }
    }
}
