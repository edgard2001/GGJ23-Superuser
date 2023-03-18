using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBugParts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Destroy(gameObject, 2.0f);
    }
}
