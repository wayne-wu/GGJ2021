using System;
using System.Collections;
using UnityEngine;

public class AmbienceSoundController : MonoBehaviour
{
    [SerializeField] AudioSource loopSource;

    [SerializeField] AudioSource randomSource;
    [SerializeField] AudioClip[] audioClips;

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
        randomSource.Play();
        StartCoroutine(WaitForStop(randomSource, () => { StartCoroutine(WaitForRandomTime(false, ()=> { SwitchClip(); PlayRandom(); })); }));
    }

    void PlayLoop()
    {
        loopSource.Play();
        StartCoroutine(WaitForStop(loopSource, () => { StartCoroutine(WaitForRandomTime( true, () => { SwitchClip(); PlayLoop(); })); }));
    }

    IEnumerator WaitForStop(AudioSource source, Action callBack)
    {
        while (true)
        {
            if (!source || !source.isPlaying)
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
