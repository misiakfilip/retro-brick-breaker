using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
    public AudioMixer mixer;

    [SerializeField]
    private string parameterName;

    [SerializeField]
    private Toggle audioToggle;

    private float audioDB;

    void Start()
    {
        audioToggle.isOn = PlayerPrefs.GetInt(parameterName) == 1 ? true : false;
        mixer.GetFloat(parameterName, out audioDB);
        mixer.SetFloat(parameterName, audioToggle.isOn ? audioDB : -80);
        audioToggle.onValueChanged.AddListener(ToggleAudio);
    }
    private void ToggleAudio(bool isOn)
    {
        if (isOn)
            mixer.SetFloat(parameterName, audioDB);
        else
            mixer.SetFloat(parameterName, -80);
        PlayerPrefs.SetInt(parameterName, isOn ? 1 : 0);
    }
}
