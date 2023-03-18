using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBug : MonoBehaviour
{
    public LayerMask groundLayer;
    public GameObject bug;
    public GameObject player;
    public float minSpawnRadius = 3f;
    public float maxSpawnRadius = 5f;
    public int maxbugCount = 100;
    private int bugCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnemyDrop");
    }

    IEnumerator EnemyDrop()
    {
        Vector3 bugPos;
        float randomAngle;
        float randomDistance;
        Quaternion rotation;
        Transform trans = player.transform;

        while (true)
        { 

            randomAngle = Random.Range(0.0f, 360.0f);
            rotation = Quaternion.AngleAxis(randomAngle, Vector3.up);
            randomDistance = Random.Range(minSpawnRadius, maxSpawnRadius);
            bugPos = trans.position + rotation * trans.forward * randomDistance;
            bool canSpawn = !Physics.Raycast(trans.position + Vector3.up * 0.5f, rotation * trans.forward, randomDistance + 0.5f, groundLayer);

            if (canSpawn && ++bugCount < maxbugCount)
                Instantiate(bug, bugPos, Quaternion.identity);

            //Debug.DrawRay(new Vector3(bugPos.x, bugPos.y-0.1f, bugPos.z), new Vector3(0, -1, 0), Color.blue);
            yield return new WaitForSeconds(2);
        }
    }
}
