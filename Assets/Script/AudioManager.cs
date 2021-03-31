using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip BGM;
    public AudioClip Walk;

    public AudioClip Run;
    public AudioClip Jump;

    public AudioClip DOIT;
    public AudioClip ButtonDown;

    public AudioClip ResetButton;



    #region SingleTon
    /* SingleTon */
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(AudioManager)) as AudioManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "AudioManager";
                    instance = container.AddComponent(typeof(AudioManager)) as AudioManager;
                }
            }

            return instance;
        }
    }

    #endregion

    private void Awake()
    {
        #region SingleTone

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        #endregion


    }

    public void PlaySound(string soundName)
    {
        if (soundName == "BGM")
        {
            audioSource.PlayOneShot(BGM);
        } 
        else if (soundName == "Walk")
        {
            audioSource.PlayOneShot(Walk);

        }
        else if (soundName == "Run")
        {
            audioSource.clip = Run;
            audioSource.loop = false;
            audioSource.Play();

        }
        else if (soundName == "Jump")
        {
            audioSource.PlayOneShot(Jump);

        }
        else if (soundName == "DOIT")
        {
            audioSource.PlayOneShot(DOIT);

        }
        else if (soundName == "ButtonDown")
        {
            audioSource.clip = ButtonDown;
            audioSource.loop = false;
            audioSource.Play();

        }
        else if (soundName == "ResetButton")
        {
            audioSource.clip = ResetButton;
            audioSource.loop = false;
            audioSource.Play();

        }

        

    }
}
