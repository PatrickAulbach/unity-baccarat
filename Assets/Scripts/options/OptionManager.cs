using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
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
}
