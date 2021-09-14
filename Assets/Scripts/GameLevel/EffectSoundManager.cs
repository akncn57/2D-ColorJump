using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundManager : MonoBehaviour
{
    private AudioSource audioSrc;
    private float effectVolume = 0.50f;

    private void Awake()
    {
        // OnLoad don't destroy this game object.
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Get Auido Source component.
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSrc.volume = effectVolume;
    }

    public void SetVolume(float vol)
    {
        // Slider value equal auido source value.
        effectVolume = vol;
    }
}
