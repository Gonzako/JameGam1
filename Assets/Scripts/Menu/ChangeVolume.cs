using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void adjustVolume()
    {
        AudioListener.volume = slider.value;
    }
}
