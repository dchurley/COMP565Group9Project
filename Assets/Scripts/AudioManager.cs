using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip sound;

    private void Start()
    {
        musicSource.clip = sound;
        musicSource.Play();
    }
}
