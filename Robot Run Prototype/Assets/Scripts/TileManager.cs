﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -4.0f;
    private float tileLength = 4.0f;
    private int amountTilesOnScreen = 10;

    private List<GameObject> activeTiles;
    private List<GameObject> Ramps;
    private float safeZone = 8.0f;

    private int lastPrefabIndex = 0;

    void Start() {
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amountTilesOnScreen; i++)
        {
            if (i < 5)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (playerTransform.position.z - safeZone > (spawnZ - amountTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
