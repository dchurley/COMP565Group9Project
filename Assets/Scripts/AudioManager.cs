using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] Slider volumeSlider;

    public AudioClip sound;
    public AudioClip winMusic;

    private void Start()
    {
        musicSource.clip = sound;
        musicSource.Play();
        volumeSlider.onValueChanged.AddListener(delegate { updateVolumeSlider(); });
        musicSource.volume = PlayerPrefs.GetFloat("volumeSlider", 0.75f);
    }

    public void PlayWinMusic()
    {
        musicSource.clip = winMusic;
        musicSource.Play();
    }

    void updateVolumeSlider()
    {
        musicSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volumeSlider", volumeSlider.value);
    }
}
