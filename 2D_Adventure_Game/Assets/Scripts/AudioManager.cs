using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        var obj = FindObjectsOfType<AudioManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.name == name && !s.source.isPlaying)
            {
                if (name == "MainTheme")
                {
                    s.source.loop = true;
                }
                s.source.Play();
            }
        }
    }

    public void PlayOneShot(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name && !s.source.isPlaying)
            {
                if (name == "MainTheme")
                {
                    s.source.loop = true;
                }
                s.source.PlayOneShot(s.clip);
            }
        }
    }
}
