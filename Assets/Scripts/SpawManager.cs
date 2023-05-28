using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float reapeatRate = 2;
    private float startDelay = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // khoi tao
        InvokeRepeating("SpawnObstacle", startDelay, reapeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // tao moi doi tuong chuong ngai vat moi dua vaò thông tin obstaclePrefab 
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
