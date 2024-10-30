using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    private static MainMenuAudio instance;
    private AudioSource audioSource;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        PlayAudio();
    }

    public void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume); // Set audio volume, clamp between 0 and 1
        }
    }

    public float GetVolume()
    {
        return audioSource != null ? audioSource.volume : 0; // Get current audio volume, return 0 if null
    }

    // Optionally mute/unmute audio
    public void MuteAudio()
    {
        if (audioSource != null)
        {
            audioSource.volume = 0; // Mute audio
        }
    }

    public void UnmuteAudio(float volume)
    {
        SetVolume(volume); // Restore volume
    }
}
