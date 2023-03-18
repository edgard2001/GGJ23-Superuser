using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pulsePrefab;
    [SerializeField] private Transform center;
    private GameObject pulseObject;


    // Start is called before the first frame update
    void Start()
    {
        pulseObject = GameObject.Instantiate(pulsePrefab, center);
        StartCoroutine("respawn");
    }

    IEnumerator respawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            pulseObject.transform.position = center.position;
        }
    }

}
