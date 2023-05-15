using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerController : MonoBehaviour
{
    public AudioSource audioSource;
    public Image image;

    public Sprite[] speakers;

    // Start is called before the first frame update
    void Start()
    {
        if (GeneralData.audioMuteStt == false)
        {
            image.sprite = speakers[0];
            audioSource.Play();

        }
        else
        {
            image.sprite = speakers[1];
            audioSource.Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateSpeaker()
    {
        if (GeneralData.audioMuteStt == false)
        {
            GeneralData.audioMuteStt = true;
            audioSource.Pause();
            image.sprite = speakers[1];

        }
        else
        {
            GeneralData.audioMuteStt = false;
            audioSource.Play();
            image.sprite = speakers[0];
        }
    }
}
