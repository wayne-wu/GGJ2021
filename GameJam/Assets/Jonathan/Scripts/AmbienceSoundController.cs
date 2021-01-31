using System;
using System.Collections;
using UnityEngine;

public class AmbienceSoundController : MonoBehaviour
{
    public static AmbienceSoundController Instance { get; private set; }

    [SerializeField] AudioSource loopSource;

    [SerializeField] AudioSource randomSource;
    [SerializeField] AudioClip[] audioClips;

    void Awake()
    {
        var instances = FindObjectsOfType<AmbienceSoundController>();
        if (instances.Length > 1)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UnMute()
    {
        if (loopSource && randomSource)
        {
            loopSource.Stop();
            randomSource.Stop();
            loopSource.mute = false;
            randomSource.mute = false;
            PlayLoop();
            PlayRandom();
        }
    }

    void OnEnable()
    {
        PlayLoop();
        PlayRandom();
    }

    void OnDisable()
    {
        loopSource.Stop();
        randomSource.Stop();
    }

    void SwitchClip()
    {
        var clipNum = UnityEngine.Random.Range(0, audioClips.Length - 1);
        randomSource.clip = audioClips[clipNum];
    }

    void PlayRandom()
    {
        if (!randomSource.mute)
        {
            randomSource.Play();
        }
        StartCoroutine(WaitForStop(randomSource, () => { StartCoroutine(WaitForRandomTime(false, ()=> { SwitchClip(); PlayRandom(); })); }));
    }

    void PlayLoop()
    {
        if (!loopSource.mute)
        {
            loopSource.Play();
        }
        StartCoroutine(WaitForStop(loopSource, () => { StartCoroutine(WaitForRandomTime( true, () => { SwitchClip(); PlayLoop(); })); }));
    }

    IEnumerator WaitForStop(AudioSource source, Action callBack)
    {
        while (true)
        {
            if (!source.isPlaying && !source.mute)
                break;
            yield return null;
        }
        callBack?.Invoke();
    }

    IEnumerator WaitForRandomTime(bool isLoop, Action callBack)
    {
        float randomTime;
        if (isLoop)
        {
            randomTime = UnityEngine.Random.Range(0f, 10f);
        }
        else
        { 
            randomTime = UnityEngine.Random.Range(5f, 15f);
        }
        yield return new WaitForSeconds(randomTime);
        callBack?.Invoke();
    }
}
