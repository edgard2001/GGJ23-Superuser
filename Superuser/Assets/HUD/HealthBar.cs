using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    bool isDead = false;
    public Slider slider;
    float progress = 0.0f;
    float time = 0.0f;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 1.0f)
        {
            UpdateProgress(0.025f);
            time = 0.0f;
        }

        if(progress >= 1.0f)
        {
            isDead = true;
            if(isDead == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void UpdateProgress(float increment)
    {
        progress += increment;
        if (progress < 0.0f) progress = 0.0f;
        slider.value = progress;
    }
}
