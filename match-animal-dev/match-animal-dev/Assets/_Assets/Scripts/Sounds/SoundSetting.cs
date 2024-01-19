using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


public class SoundSetting : MonoBehaviour
{
    public GameObject soundOnImage;
    public GameObject soundOffIamge;
    [SerializeField] private bool isSoundOn;
    public void TurnOnSound()
    {
        SoundManager.instance.PlaySound(0);
        SoundManager.instance.audioSource.mute = false;
        isSoundOn = false;

    }
    public void TurnOffSound()
    {
        SoundManager.instance.PlaySound(0);
        SoundManager.instance.audioSource.mute = true;
        isSoundOn = true;
    }
    public void SetSoundImage()
    {
        if (isSoundOn)
        {
            soundOnImage.SetActive(true);
            soundOffIamge.SetActive(false);
            TurnOnSound();
        }
        else
        {
            soundOnImage.SetActive(false);
            soundOffIamge.SetActive(true);
            TurnOffSound();
        }
    }
}
