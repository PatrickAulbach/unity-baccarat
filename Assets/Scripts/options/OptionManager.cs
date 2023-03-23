using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI volumeNumberText;
    [SerializeField] TextMeshProUGUI gameSpeedNumberText;
    public void SetVolume(float volume)
    {
        OptionValues.volume = (int) volume;
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
