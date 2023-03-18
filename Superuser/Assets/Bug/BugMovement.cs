using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public GameObject player;
    
    private Vector3 currentTarget;
    private float speed = 2f;
    private float timer = 0f;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        //changeMovement();
        animator = GetComponent<Animator>();
        currentTarget = GetComponent<Rigidbody>().position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        bool isMoving = !GetComponent<Rigidbody>().position.Equals(currentTarget);
        animator.SetBool("IsMoving", isMoving);
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = !GetComponent<Rigidbody>().position.Equals(currentTarget);
        animator.SetBool("IsMoving", isMoving);
        DoMove();
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            if ((GetComponent<Rigidbody>().position - player.transform.position).magnitude < 8)
            {
                targetPlayer();
            }
            else
            {
                changeMovement();
            }
            timer = 0f;
        }
        
    }

    private void targetPlayer()
    {
        currentTarget = new Vector3(player.transform.position.x, GetComponent<Rigidbody>().position.y, player.transform.position.z);
        Debug.DrawRay(GetComponent<Rigidbody>().position, currentTarget - GetComponent<Rigidbody>().position, Color.red);
    }

    private void changeMovement()
    {
        //GetComponent<Rigidbody>().velocity = Vector3.zero;
        currentTarget = GetComponent<Rigidbody>().position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        Debug.DrawRay(GetComponent<Rigidbody>().position, currentTarget - GetComponent<Rigidbody>().position, Color.red);
    }

    private void DoMove()
    {
        Vector3 newDir = Vector3.RotateTowards(GetComponent<Rigidbody>().transform.forward, currentTarget - GetComponent<Rigidbody>().position, 12 * Time.deltaTime, 0.0f);
        GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(newDir);
        Debug.DrawRay(GetComponent<Rigidbody>().position, newDir, Color.red);
        //GetComponent<Rigidbody>().transform.LookAt(currentTarget);
        GetComponent<Rigidbody>().position = Vector3.MoveTowards(GetComponent<Rigidbody>().position, currentTarget, speed * Time.deltaTime);
    }
}
