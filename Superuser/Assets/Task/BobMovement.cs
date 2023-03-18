using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{

    [SerializeField] private float displacement = 0.3f;
    [SerializeField] private float speedMultiplier = 1.5f;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originalPosition + displacement * Vector3.up * Mathf.Sin(Time.time * speedMultiplier);
    }
}
