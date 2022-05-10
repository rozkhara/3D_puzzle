using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeText : MonoBehaviour
{
    [SerializeField]
    private Text bgmVolume;
    [SerializeField]
    private Text sfxVolume;

    [SerializeField]
    private SliderControl sliderControl;

    private void Update()
    {
        bgmVolume.text = ((int)sliderControl.BGMSlider.value).ToString();
        sfxVolume.text = ((int)sliderControl.SFXSlider.value).ToString();
    }
}
