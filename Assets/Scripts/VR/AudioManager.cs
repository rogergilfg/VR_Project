using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private GameObject sfxPrefab;
    [SerializeField] private AudioClip footstepsClip;
    [SerializeField] private AudioClip musicClip;

    private AudioSource musicSource;
    private AudioSource footstepsSource;

    private void Awake()
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

        musicSource = gameObject.AddComponent<AudioSource>();
        footstepsSource = gameObject.AddComponent<AudioSource>();
        footstepsSource.playOnAwake = false;
    }

    void Start()
    {
        PlayMusic(0.1f);
    }

    public void PlayMusic(float volume)
    {
        musicSource.clip = musicClip;
        musicSource.volume = volume;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip, float volume, bool loop, Vector3 position)
    {
        GameObject sfxClone = Instantiate(sfxPrefab, position, Quaternion.identity);
        AudioSource cloneSource = sfxClone.GetComponent<AudioSource>();
        cloneSource.clip = clip;
        cloneSource.volume = volume;
        cloneSource.loop = loop;
        cloneSource.Play();

        if (loop)
        {
            Destroy(sfxClone, 5f);
        }
        else
        {
            Destroy(sfxClone, clip.length);
        }
    }

    public void PlaySteps(float volume)
    {
        footstepsSource.clip = footstepsClip;
        footstepsSource.loop = true;
        footstepsSource.volume = volume;
        footstepsSource.Play();
    }

    public void StopSteps()
    {
        footstepsSource.Stop();
    }
}
