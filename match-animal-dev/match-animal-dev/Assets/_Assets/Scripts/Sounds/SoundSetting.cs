using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class SoundSetting : MonoBehaviour
{
    public GameObject soundOnImage;
    public GameObject soundOffIamge;
    [SerializeField] private bool isSoundOff;
    private void Start()
    {
        Init();
        SetSoundImage();
    }
    private void Init()
    {
        isSoundOff = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.Sound);
    }
    public void TurnOnSound()
    {
        SoundManager.instance.PlaySound(0);
        SoundManager.instance.audioSource.mute = false;
        isSoundOff = false;
        SaveSoundValue();
    }
    public void TurnOffSound()
    {
        SoundManager.instance.PlaySound(0);
        SoundManager.instance.audioSource.mute = true;
        isSoundOff = true;
        SaveSoundValue();
    }
    public void SetSoundImage()
    {
        if (GetIsSoundOff())
        {
            TurnOnSound();
            SoundOnImage();
        }
        else
        {
            TurnOffSound();
            SoundOffImage();
        }
    }

    private bool GetIsSoundOff()
    {
        return isSoundOff;
    }

    private void SoundOffImage()
    {
        soundOnImage.SetActive(false);
        soundOffIamge.SetActive(true);
    }

    private void SoundOnImage()
    {
        soundOnImage.SetActive(true);
        soundOffIamge.SetActive(false);
    }
    private void SaveSoundValue()
    {
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.Sound, !GetIsSoundOff());
    }
}
