using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCommand : MonoBehaviour
{
    public UIManager UIManager;
    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            UIManager = new UIManager();
            UIManager.RestartLevel();
        }
    }
}
