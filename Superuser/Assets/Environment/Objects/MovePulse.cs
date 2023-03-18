using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class MovePulse : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 nextTarget;
    [SerializeField] private Vector3 previousTarget;
    [SerializeField] private bool newCenter;

    public void SetNextTarget(List<Vector3> exits)
    {
        nextTarget = exits[Random.Range(0, exits.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (newCenter == false)
        {
            transform.position += (nextTarget - transform.position).normalized * Time.deltaTime * speed;
        }
        else if ( (center - transform.position).sqrMagnitude > 0.001)
        {
            transform.position += (center - transform.position).normalized * Time.deltaTime * speed;
        }
        if ((center- transform.position).sqrMagnitude <= 0.001)
        {
            newCenter = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Circuit circuit = collision.gameObject.GetComponent<Circuit>();
            center = circuit.GetCenter().position;
            newCenter = true;
            List<Transform> exits = circuit.GetExits();
            nextTarget = exits[Random.Range(0, exits.Count)].position;
        }
    }
}
