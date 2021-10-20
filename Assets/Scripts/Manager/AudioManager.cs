using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using MoreMountains.NiceVibrations;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;
    public AudioSource audioSource;
    // public AudioSource audioSource2;
    public AudioClip peelPotatoes, cutPotatoes, fryPotatoes, collectablePositive, collectableNegative, boxSmash, win, lose;


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    // Index   Haptic Type
    //  0       No haptic
    //  1       Transient
    //  2       Continuous
    public void PlaySFX(AudioClip clip, float volume = 0.2f)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void StopSFX()
    {
        audioSource.Stop();
    }
    // public void Vibrate(int hapticType = 0)
    // {
    //     if (hapticType == 1)
    //         MMVibrationManager.TransientHaptic(1f, 1f, true, this);
    //     else if (hapticType == 2)
    //         MMVibrationManager.ContinuousHaptic(1f, 0.85f, 1f, HapticTypes.RigidImpact, this);
    // }

    // public void AudioSourceLooped(bool state)
    // {
    //     if (state)
    //         audioSource2.Play();
    //     else
    //         audioSource2.Stop();
    // }
}
