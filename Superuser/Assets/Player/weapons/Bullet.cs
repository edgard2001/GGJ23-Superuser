using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void Update(){
        var destroy = 0.5f;
        Destroy(gameObject, destroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    /*private void OnCollisionEnter(Collision collision)
     {

         if(collision.gameObject.tag == "Task")
         {
             Destroy(gameObject);
         }

     }*/
}
