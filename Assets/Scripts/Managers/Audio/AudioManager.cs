using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        EventBroadcaster.Instance.AddObserver(EventNames.GJ1_Events.PLAY_SFX, this.PlaySFX);
        EventBroadcaster.Instance.AddObserver(EventNames.GJ1_Events.STOP_SFX, this.StopSFX);
    }

    void Start()
    {
        Play("BGM");
    }

    private void OnDestroy()
    {
        Debug.Log("Removing All Observers FROM AUDIO MANAGER");
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    public void Play(string sfxName)
    {
        Parameters updateLineParams = new Parameters();
        updateLineParams.PutExtra("SFX", sfxName);
        EventBroadcaster.Instance.PostEvent(EventNames.GJ1_Events.PLAY_SFX, updateLineParams);
    }

    private void PlaySFX(Parameters param)
    {
        string name = param.GetStringExtra("SFX", "BGM");

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound file '" + name + "' not found!!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string sfxName)
    {
        Parameters updateLineParams = new Parameters();
        updateLineParams.PutExtra("SFX", sfxName);
        EventBroadcaster.Instance.PostEvent(EventNames.GJ1_Events.PLAY_SFX, updateLineParams);
    }

    private void StopSFX(Parameters param)
    {
        string name = param.GetStringExtra("SFX", "BGM");

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound file '" + name + "' not found!!");
            return;
        }
        s.source.Stop();
    }
}
