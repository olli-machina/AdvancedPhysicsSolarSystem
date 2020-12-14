using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    public Transform maxX, minX, maxY, minY; //Game Boundaries
    public GameObject bullet;

    //UI

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
    }

    //Spawn in Random Bullet
    void SpawnBullet()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Vector3 randomStartPosition = new Vector3(Random.Range(minX.position.x, maxX.position.x), Random.Range(minY.position.y, maxY.position.y), 0f);
            Instantiate(bullet, randomStartPosition, Quaternion.identity);
        }
    }
}
