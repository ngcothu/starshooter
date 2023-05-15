using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(playAudioSequentially());
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        if(GeneralData.audioMuteStt == false)
        {
            //1.Loop through each AudioClip
            for (int i = 0; i < audioClips.Length; i++)
            {
                if (GeneralData.audioMuteStt == false)
                {
                    //2.Assign current AudioClip to audiosource
                    audioSource.clip = audioClips[i];

                    //3.Play Audio
                    audioSource.Play();

                    //4.Wait for it to finish playing
                    while (audioSource.isPlaying)
                    {
                        yield return null;
                    }
                }
                //5. Go back to #2 and play the next audio in the adClips array
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
