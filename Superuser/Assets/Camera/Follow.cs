using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 forward = -Offset;
        Vector3 right = Vector3.Cross(forward, new Vector3(forward.x, 0, forward.z));
        Vector3 up = Vector3.Cross(right, forward);
        transform.rotation = Quaternion.LookRotation(forward, up) * transform.rotation;
        transform.position = playerTransform.position + Offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + Offset, Time.deltaTime * 100);
    }
}
