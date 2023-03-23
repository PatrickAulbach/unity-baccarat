using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI volumeNumberText;
    [SerializeField] TextMeshProUGUI gameSpeedNumberText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider gameSpeedSlider;
    [SerializeField] Toggle toggle;

    private void Awake() {
        volumeSlider.value = OptionValues.volume;
        gameSpeedSlider.value = OptionValues.volume;
        toggle.isOn = OptionValues.isRandomized;
        SetVolume(OptionValues.volume);
    }
    public void SetVolume(float volume)
    {
        OptionValues.volume = (int) volume;
        audioSource.volume = volume / 100;
    }

    public void SetIsRandomized(bool isRandomized)
    {
        OptionValues.isRandomized = isRandomized;
    }

    public void SetGameSpeed(float gameSpeed)
    {
        OptionValues.gameSpeed = (int) gameSpeed;
    }

    public void SetVolumeNumberText(float text)
    {
        volumeNumberText.text = text.ToString();
    }

    public void SetGameSpeedNumberText(float text)
    {
        gameSpeedNumberText.text = text.ToString();
    }
}
