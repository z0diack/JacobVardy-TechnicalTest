using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    [Header("Public Objects")]
    public GameObject player;
    public Transform spawnPos;

    GameObject objectList;

    // Start is called before the first frame update
    void Start()
    {
        objectList = GameObject.Find("Objects");
    }

    public void CreateCube()
    {
        GameObject newSpawn = Instantiate(cube, spawnPos);
        player.GetComponent<PlayerInput>().itemPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    public void CreateSphere()
    {
        GameObject newSpawn = Instantiate(sphere, spawnPos);
        player.GetComponent<PlayerInput>().itemPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    public void CreateCylinder()
    {
        GameObject newSpawn = Instantiate(cylinder, spawnPos);
        player.GetComponent<PlayerInput>().itemPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    public void CreateCapsule()
    {
        GameObject newSpawn = Instantiate(capsule, spawnPos);
        player.GetComponent<PlayerInput>().itemPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    public void DestoryAll()
    {
        for (int i = objectList.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(objectList.transform.GetChild(i).gameObject);
        }
    }
}
