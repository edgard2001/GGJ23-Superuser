using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Vector3 forward;
    [SerializeField] private Vector3 right;
    [SerializeField] private Vector3 up;

    // Start is called before the first frame update
    void Start()
    {
        forward = -Offset;
        right = Vector3.Cross(forward, new Vector3(forward.x, 0, forward.z));
        up = Vector3.Cross(right, forward);
        transform.rotation = Quaternion.LookRotation(forward, up) * transform.rotation;
        transform.position = playerTransform.position + Offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + Offset, Time.deltaTime * 100);
    }
}
