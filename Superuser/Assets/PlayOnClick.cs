using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnClick : MonoBehaviour
{
    public AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound();
    }

    public void PlaySound()
    {
        if(Input.GetMouseButtonDown(0))
        {
            print("sound played");
            gunSound.Play();
        }
    }
}
