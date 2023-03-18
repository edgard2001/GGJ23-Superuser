using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Task : MonoBehaviour
{
    [SerializeField] private GameObject uncompleteModel;
    [SerializeField] private GameObject completeModel;
    [SerializeField] private GameObject indicator;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image slider;
    [SerializeField] private float holdTime = 3f;
    [SerializeField] private HealthBar healthBar;
    private float progressTime = 0f;
    private bool playerInRange = false;
    private bool taskComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!taskComplete && playerInRange && Input.GetKey(KeyCode.E))
            progressTime += Time.deltaTime;
        else
            progressTime = 0f;

        slider.fillAmount = progressTime / holdTime;

        if (progressTime >= holdTime)
        {
            playerInRange = false;
            text.text = "";

            indicator.SetActive(false);
            uncompleteModel.SetActive(false);
            completeModel.SetActive(true);
			
            healthBar.UpdateProgress(-0.4f);
			taskComplete = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!taskComplete && other.CompareTag("Player"))
        {
            playerInRange = true;
            text.text = "E";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            playerInRange = false;
            text.text = "";
        }
    }
}
