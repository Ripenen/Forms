using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public SaveLoad SaveLoad;
    public GameObject MusicObject;

    private AudioSource _audioSource;
    private GameObject _music;

    private void Awake()
    {

        _audioSource = MusicObject.GetComponent<AudioSource>();

        if (SaveLoad.LoadVolume() == "True")
        {
            PlayMusic();
        }
        else
        {
            StopMusic();
        }
    }

    public void PlayMusic()
    {
        _music = Instantiate(MusicObject, transform.parent);

        DontDestroyOnLoad(_music);

        if (FindObjectsOfType<AudioSource>().Length >= 2)
        {
            Destroy(_music);
        }

        _audioSource.enabled = true;
    }

    public void StopMusic()
    {
        _audioSource.Stop();
        Destroy(_music);

        if(FindObjectOfType<AudioSource>() != null)
        {
            Destroy(FindObjectOfType<AudioSource>().gameObject);
        }
    }
}
