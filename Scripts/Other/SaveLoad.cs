using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveScore(int score)
    {
        PlayerPrefs.SetInt("MaxScore", score);
    }

    public static void SaveVibration(string vibration)
    {
        PlayerPrefs.SetString("Vibration", vibration);
    }

    public static void SaveVolume(string volume)
    {
        PlayerPrefs.SetString("Volume", volume);
    }

    public static int LoadScore()
    {
        return PlayerPrefs.GetInt("MaxScore");
    }

    public static string LoadVibration()
    {
        return PlayerPrefs.GetString("Vibration");
    }

    public static string LoadVolume()
    {
        return PlayerPrefs.GetString("Volume");
    }
}
