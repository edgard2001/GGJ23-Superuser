using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

   public GameObject gameOverMenu;
   public bool isDead;

   private void OnEnable()
   {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
        isDead = true;
   }

   private void OnDisable()
   {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
        isDead = false;
   }

   public void EnableGameOverMenu()
   {
        gameOverMenu.SetActive(true);
   }

   public void RestartLevel()
   {
     if(isDead == true)
     {
          if(Input.GetKeyDown(KeyCode.R))
          {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          }
     }
        
   }
}
