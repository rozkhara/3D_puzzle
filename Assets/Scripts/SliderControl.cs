using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider SFXSlider;
    public void ControlBGM()
    {
        SoundManager.Instance.SetBGMVolume(BGMSlider.value / 100);
    } 

    public void ControlSFX()
    {
        SoundManager.Instance.SetSFXVolume(SFXSlider.value / 100);
    }
}
