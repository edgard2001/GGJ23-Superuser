using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isPlayable = false;

    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            isPlayable = true;
            if(isPlayable == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
            Debug.Log("Pressed P");
        }

        if(Input.GetKey(KeyCode.Escape))
        {
                Application.Quit();
                Debug.Log("Pressed ESC");
        }
    }
}
