using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public int colums = 8;
    public int rows = 8;

    public GameObject[] floorTiles;
    public GameObject[] outerWallTiles;

    public void SetupScene()
    {
        Debug.Log("Ejecutado!");
    }
}
