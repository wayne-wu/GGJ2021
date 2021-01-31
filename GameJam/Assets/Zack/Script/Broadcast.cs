using System.Collections;
using UnityEngine;

public class Broadcast : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private AudioClip[] m_clips;
    public bool KeepBroadcast { get; set; } = true;

    private void Start()
    {
        StartCoroutine(PlayBroadcast());
    }

    IEnumerator PlayBroadcast()
    {
        while (true)
        {
            for (int i = 0; i < m_clips.Length; i++)
            {
                m_audioSource.PlayOneShot(m_clips[i]);
                yield return new WaitForSeconds(0.5f);
            }
        
            yield return new WaitForSeconds(6f);

            if (KeepBroadcast == false)
            {
                break;
            }
        }
    }
}