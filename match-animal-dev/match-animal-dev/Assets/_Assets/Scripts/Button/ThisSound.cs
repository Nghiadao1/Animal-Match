using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisSound : MonoBehaviour
{
    public AudioSource thisSound;
    public void PlayThisSound()
    {
        thisSound.Play();
    }
}
