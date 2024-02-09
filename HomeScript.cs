using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public AudioSource HomeSound;
    // Start is called before the first frame update
    void Start()
    {
        HomeSound.Play();
    }
    public void Player()
    {
        SceneManager.LoadScene("PLAY");
        HomeSound.mute = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}
