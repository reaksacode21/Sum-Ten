using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioScript : MonoBehaviour
{
    public AudioSource audios;
    public AudioSource completed, onClick;
    public Button audiosBnt;
    public Sprite[] sprites;
    bool isOn = true;

    public void Audio()
    {
        isOn = !isOn;
        if (isOn)
        {
            audiosBnt.image.sprite = sprites[0];
            audios.Play();
            audios.mute = false;
        }else if (!isOn)
        {
            audiosBnt.image.sprite = sprites[1];
            audios.Play();
            audios.mute = true;
        }
    }

}
