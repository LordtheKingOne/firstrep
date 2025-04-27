using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager instance; //  make a static instance

    [Header("----Audio Source----")]
    [SerializeField] AudioSource musicSource;

    [Header("----Audio Clip----")]
    public AudioClip background;
    public AudioClip death;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); //  if another already exists, destroy the new one
            return;
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void RestartMusic()
    {
        musicSource.Stop();
        musicSource.clip = background;
        musicSource.Play();
    }
}
