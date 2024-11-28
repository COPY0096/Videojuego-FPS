using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource ShootingChannel;

    public AudioClip P1911Shot;
    public AudioClip M4Shot;

    public AudioSource reloadingSoundM4;
    public AudioSource reloadingSoundM1911;

    public AudioSource emptyMagazineSoundM1911;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol1911:
            ShootingChannel.PlayOneShot(P1911Shot);
                break;
            case WeaponModel.M4:
            ShootingChannel.PlayOneShot(M4Shot);
                break;
            default:
                Debug.LogWarning("No shooting sound for this weapon.");
                break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol1911:
                reloadingSoundM1911.Play();
                break;
            case WeaponModel.M4:
                reloadingSoundM4.Play();
                break;
            default:
                Debug.LogWarning("No reloading sound for this weapon.");
                break;
        }
    }

    
}


