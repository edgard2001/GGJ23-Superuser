using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDeath : MonoBehaviour
{
    public GameObject ExplodingBug;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // Decrease memory usage bar
            healthBar.UpdateProgress(-0.02f);
            
            Destroy(gameObject);

            BugDeath bugParts = (Instantiate(ExplodingBug, transform.position, transform.rotation)).gameObject.GetComponent<BugDeath>();
            bugParts.ExplodingBug = ExplodingBug;

            //GameObject bugParts = Instantiate(Resources.Load(), transform.position, transform.rotation); 

            bugParts.GetComponent<Rigidbody>().AddExplosionForce(1, transform.position, 1);
            for (int i = 0; i < bugParts.transform.childCount; i++)
            {
                bugParts.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }


        }
    }
}
