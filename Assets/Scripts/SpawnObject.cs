using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    GameObject cube;
    [SerializeField]
    GameObject sphere;
    [SerializeField]
    GameObject cylinder;
    [SerializeField]
    GameObject pyramid;

    [Header("Public Objects")]
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform spawnPos;

    GameObject objectList;

    void Start()
    {
        objectList = GameObject.Find("Objects");
    }

    /// <summary>
    /// Used to create a cube, used in the button onClick().
    /// </summary>
    public void CreateCube()
    {
        GameObject newSpawn = Instantiate(cube, spawnPos);
        player.GetComponent<PlayerInput>().objPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    /// <summary>
    /// Used to create a sphere, used in the button onClick().
    /// </summary>
    public void CreateSphere()
    {
        GameObject newSpawn = Instantiate(sphere, spawnPos);
        player.GetComponent<PlayerInput>().objPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    /// <summary>
    /// Used to create a cylinder, used in the button onClick().
    /// </summary>
    public void CreateCylinder()
    {
        GameObject newSpawn = Instantiate(cylinder, spawnPos);
        player.GetComponent<PlayerInput>().objPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    /// <summary>
    /// Used to create a pyramid, used in the button onClick().
    /// </summary>
    public void CreatePyramid()
    {
        GameObject newSpawn = Instantiate(pyramid, spawnPos);
        player.GetComponent<PlayerInput>().objPicked = newSpawn;
        player.GetComponent<PlayerInput>().ready = false;
        newSpawn.transform.parent = objectList.transform;
    }

    /// <summary>
    /// Function used to destory all the objects currently spawned in.
    /// </summary>
    public void DestoryAll()
    {
        for (int i = objectList.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(objectList.transform.GetChild(i).gameObject);
        }
    }
}
