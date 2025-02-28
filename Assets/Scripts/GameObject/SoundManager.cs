using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip BGM;

    // V Player

    [SerializeField]
    private AudioClip cardSound;

    [SerializeField]
    private AudioClip[] swordSounds;

    [SerializeField]
    private AudioClip[] bombSounds;

    [SerializeField]
    private AudioClip healSound;

    [SerializeField]
    private AudioClip levelSound;

    // V Enemy

    [SerializeField]
    private AudioClip bullSound;

    [SerializeField]
    private AudioClip[] ghostSounds;

    [SerializeField]
    private AudioClip growlSound;

    [SerializeField]
    private AudioClip[] lightningSounds;

    private void Awake()
    {
        // SoundManager ΩÃ±€≈Ê
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource.clip = BGM;

        audioSource.Play();
    }

    // V Player

    public void PlayCardThrowingSound()
    {
        audioSource.PlayOneShot(cardSound, Random.Range(0.2f, 0.5f));
    }

    public void PlaySwordSweepingSound()
    {
        audioSource.PlayOneShot(swordSounds[Random.Range(0, 4)], Random.Range(0.2f, 0.5f));
    }

    public void PlayBombExplosionSound()
    {
        audioSource.PlayOneShot(bombSounds[Random.Range(0, 2)], Random.Range(0.3f, 0.5f));
    }

    public void PlayHealSound()
    {
        audioSource.PlayOneShot(healSound, 0.5f);
    }

    public void PlayLevelUpSound()
    {
        audioSource.PlayOneShot(levelSound, 0.5f);
    }

    // V Enemy

    public void BullExplodeSound()
    {
        audioSource.PlayOneShot(bullSound, 0.7f);
    }

    public void PlayGhostSound()
    {
        audioSource.PlayOneShot(ghostSounds[Random.Range(0, 4)], Random.Range(0.05f, 0.1f));
    }

    public void PlayGrowlingSound()
    {
        audioSource.PlayOneShot(growlSound, 0.3f);
    }

    public void PlayLightningSound()
    {
        audioSource.PlayOneShot(lightningSounds[Random.Range(0, 2)], Random.Range(1f, 1.2f));
    }
}
