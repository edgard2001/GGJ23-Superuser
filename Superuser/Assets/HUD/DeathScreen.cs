using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    bool isPlayable = false;

    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            isPlayable = true;
            if(isPlayable == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            
            Debug.Log("Pressed R");
        }
    }
}
