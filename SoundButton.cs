using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public GameObject soundON;
    public GameObject soundOFF;
    private AudioSource sound001;

    public void OnPushButton(bool soundEnabled)
    {
        if(soundEnabled)
        {
            soundON.SetActive(true);
            soundOFF.SetActive(false);
            AudioListener.volume = 0f;
        }

        else
        {
            soundON.SetActive(false);
            soundOFF.SetActive(true);
            AudioListener.volume = 0.05f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        soundON.SetActive(true);
        soundOFF.SetActive(false);

        sound001 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
