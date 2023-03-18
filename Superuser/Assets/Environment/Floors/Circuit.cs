using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private List<Transform> exits;

    public Transform GetCenter() { return center; }
    public List<Transform> GetExits() { return exits; }
 
}
