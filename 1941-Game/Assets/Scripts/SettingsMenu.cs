using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resDropdown;
    Resolution[] res;

    void Start()
    {
        res = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        for(int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + "x" + res[i].height;
            options.Add(option);
        }

        resDropdown.AddOptions(options);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
