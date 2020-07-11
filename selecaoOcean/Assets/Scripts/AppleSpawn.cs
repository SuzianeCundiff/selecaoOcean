using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{
    public int appleSpawnSize = 7;
    public GameObject applePrefab;
    public float spawnRate = 2f;
    public float columnMin = -2f;
    public float columnMax = 2f;

    private GameObject[] apples;
    private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentApple = 0;


    // Start is called before the first frame update
    void Start()
    {
        CreateApples();
    }

    void CreateApples(){
        apples = new GameObject[appleSpawnSize];
        for (int i = 0; i < appleSpawnSize; i++)
        {
            apples[i] = (GameObject) Instantiate(applePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate){
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            apples[currentApple].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentApple++;

            if(currentApple >= appleSpawnSize){
                CreateApples();
                currentApple = 0;
            }
        }
    }
}
