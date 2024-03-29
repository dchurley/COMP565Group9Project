using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip sound;
    public AudioClip winMusic;

    private void Start()
    {
        musicSource.clip = sound;
        musicSource.Play();
    }

    public void PlayWinMusic()
    {
        musicSource.clip = winMusic;
        musicSource.Play();
    }
}
