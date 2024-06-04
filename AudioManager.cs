using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clip--------------")]
    public AudioClip Footstep;
    public AudioClip Sword;
    public AudioClip Music;

    int musicPlaying = 1;



    private static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        MusicSource.clip = Music;
        MusicSource.Play();

    }

    private void Update()
    {
        if (MusicSource.isPlaying == false)
        {
            musicPlaying = musicPlaying * -1;
            if (musicPlaying == 1)
            {
                MusicSource.clip = Music;
            }
            if (musicPlaying == -1)
            {
                MusicSource.clip = Music;
            }
            MusicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayWalk(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
