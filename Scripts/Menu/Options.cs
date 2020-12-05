using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject[] Buttons;
    public SaveLoad SaveLoad;
    public Music Music;

    private Button _option;
    private bool isOpen;

    private string Sound;
    private string Vibration;

    private void Awake()
    {
        Sound = SaveLoad.LoadVolume();
        Vibration = SaveLoad.LoadVibration();

        CheckSettings();
    }
    void Start()
    {
        _option = GetComponent<Button>();
    }

    public void Clickable(Image Button)
    {
        if(Button.gameObject.name == "Phone")
        {
            if (Vibration == "True")
            {
                Button.color = new Color(255, 255, 255, 0.3f);
                Vibration = "False";
            }
            else
            {
                Button.color = new Color(255, 255, 255, 1);
                Vibration = "True";
            }

            SaveLoad.SaveVibration(Vibration);

        }

        if (Button.gameObject.name == "Sound")
        {
            if (Sound == "True")
            {
                Button.color = new Color(255, 255, 255, 0.3f);
                Music.StopMusic();
                Sound = "False";
            }
            else
            {
                Button.color = new Color(255, 255, 255, 1);
                Music.PlayMusic();
                Sound = "True";
            }

            SaveLoad.SaveVolume(Sound);
        }
    }

    public void OpenOptions()
    {
        if (isOpen == false)
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(true);
            }
            isOpen = true;
        }
        else
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(false);
            }

            isOpen = false;
        }
    }

    public void CheckSettings()
    {
        if (SaveLoad.LoadVibration() == "True")
        {
            Buttons[1].GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        else
        {
            Buttons[1].GetComponent<Image>().color = new Color(255, 255, 255, 0.3f);
        }

        if (SaveLoad.LoadVolume() == "True")
        {
            Buttons[2].GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        else
        {
            Buttons[2].GetComponent<Image>().color = new Color(255, 255, 255, 0.3f);
        }
    }
}
