using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = -1.0f;
    private float tileLength = 10.0f;
   private int amnTilesOnScreen = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i< amnTilesOnScreen; i++)
        {
            spawnTile();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if( playerTransform.position.z > (spawnZ - amnTilesOnScreen * tileLength))
        {
            spawnTile();
        }

    }

    private void spawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }
}
