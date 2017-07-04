using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int colums = 8;
    public int rows = 8;

    public GameObject[] floorTiles;
    public GameObject[] outerWallTiles;

    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;

    public GameObject exit;

    private List<Vector2> gridPositions = new List<Vector2>();

    private Transform boardHolder;

    private void InitializeList() {
        gridPositions.Clear();
        for(int x = 1; x < colums -1; x++) {
            for(int y = 1; y < rows -1; y++) {
                gridPositions.Add(new Vector2(x, y));
            }
        }
    }

    private Vector2 RandomPosition() {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector2 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    private void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max) {
        int objectCount = Random.Range(min, max + 1);
        for(int i = 0; i < objectCount; i++) {
            Vector2 randomPosition = RandomPosition();
            GameObject tileChoice = GetRandomInArray(tileArray);
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene() {
        BoardSetup();
        InitializeList();
        LayoutObjectAtRandom(wallTiles, 5, 9);
        LayoutObjectAtRandom(foodTiles, 1, 5);
    }

    private void BoardSetup() {

        boardHolder = new GameObject("Board").transform;

        for(int x = -1; x < colums + 1; x++) {
            for(int y = -1; y < rows +1; y++) {
                GameObject toInstanciate = GetRandomInArray(floorTiles);

                if (x == -1 || y == -1 || x == colums || y == rows) {
                    toInstanciate = GetRandomInArray(outerWallTiles);
                }

                GameObject instance = Instantiate(toInstanciate, new Vector2(x, y), Quaternion.identity);
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    private GameObject GetRandomInArray(GameObject[] array) {
        return array[Random.Range(0, array.Length)];
    }
}
