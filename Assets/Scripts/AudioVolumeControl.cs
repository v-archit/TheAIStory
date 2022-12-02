using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeControl : MonoBehaviour
{
    public Slider bgSlider;
    public Slider effectsSlider;
    public void SetVolume(bool isBackground)
    {
        if (isBackground)
        {
            if (gameObject.name == "BGAudioSources")
            {
                foreach (AudioSource source in gameObject.GetComponentsInChildren<AudioSource>())
                {
                    source.volume = bgSlider.value;
                }
            }
		}
        else
		{
			if (gameObject.name == "EffectsAudioSources")
			{
				foreach (AudioSource source in gameObject.GetComponentsInChildren<AudioSource>())
				{
					source.volume = effectsSlider.value;
				}
			}
		}
	}
}
