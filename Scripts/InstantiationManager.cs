using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    [SerializeField] List<Transform> instantiationPoints = new List<Transform>();
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] List<GameObject> fuelPrefabs = new List<GameObject>();
    [SerializeField] float moveSpeed = -200f;
    [SerializeField] float minTimeToSpawn = 5f;
    [SerializeField] float maxTimeToSpawn = 10f;

    float timer1, timer2, timer3, timer4,
    timer1Max, timer2Max, timer3Max, timer4Max;

    int fuelPrefabNumber;

    void Start()
    {
        minTimeToSpawn = 5f;
        maxTimeToSpawn = 10f;
        moveSpeed = -200f;
        //Debug.Log(minTimeToSpawn);
        //Debug.Log(maxTimeToSpawn);
        //Debug.Log(moveSpeed);
        SetUpTimerMax();
    }

    // Update is called once per frame
    void Update()
    {
        if(!LevelManager.gameOver && !LevelManager.gamePlayed) {
            CountDownAndInstantiate();
            if(LevelManager.miles % 10 == 0) {
                if(minTimeToSpawn > 2f) {
                    minTimeToSpawn -= .1f;
                }
                if(maxTimeToSpawn > 4f) {
                    maxTimeToSpawn -= .1f;
                }
                moveSpeed -= 10f;
            }
        }
        
    }

    void SetUpTimerMax() {
        timer1Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
        timer2Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
        timer3Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
        timer4Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
    }

    void CountDownAndInstantiate() {
        timer1 += Time.fixedDeltaTime;
        timer2 += Time.fixedDeltaTime;
        timer3 += Time.fixedDeltaTime;
        timer4 += Time.fixedDeltaTime;

        if(timer1 >= timer1Max) {
            //Debug.Log("ONE!");
            int rand3 = Mathf.RoundToInt(Random.Range(3f,6f));
            int rand1 = Mathf.RoundToInt(Random.Range(0,rand3));
            int rand2 = Mathf.RoundToInt(Random.Range(0,rand3));
            if(rand1 == rand2) {
                fuelPrefabNumber = Mathf.RoundToInt(Random.Range(0,2f));
                GameObject fuelInstance = Instantiate(fuelPrefabs[fuelPrefabNumber],instantiationPoints[0].position,Quaternion.identity) as GameObject;
                fuelInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,moveSpeed * Time.fixedDeltaTime);
            }
            else {
                int obstacleType = Mathf.RoundToInt(Random.Range(0,3f));
                GameObject obstacle = Instantiate(obstacles[obstacleType],instantiationPoints[0].position,Quaternion.identity) as GameObject;
                obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, moveSpeed * Time.fixedDeltaTime);
                //Debug.Log(obstacle.GetComponent<Rigidbody2D>().velocity);
            }
            timer1 = 0;
            timer1Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
        }
        if(timer2 >= timer2Max) {
            //Debug.Log("TWO!");
            int rand3 = Mathf.RoundToInt(Random.Range(3f,6f));
            int rand1 = Mathf.RoundToInt(Random.Range(0,rand3));
            int rand2 = Mathf.RoundToInt(Random.Range(0,rand3));
            if(rand1 == rand2) {
                fuelPrefabNumber = Mathf.RoundToInt(Random.Range(0,2f));
                GameObject fuelInstance = Instantiate(fuelPrefabs[fuelPrefabNumber],instantiationPoints[1].position,Quaternion.identity) as GameObject;
                fuelInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,moveSpeed * Time.fixedDeltaTime);
            }
            else {
                int obstacleType = Mathf.RoundToInt(Random.Range(0,3f));
                GameObject obstacle = Instantiate(obstacles[obstacleType],instantiationPoints[1].position,Quaternion.identity) as GameObject;
                obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, moveSpeed * Time.fixedDeltaTime);
                //Debug.Log(obstacle.GetComponent<Rigidbody2D>().velocity);
            }
            timer2 = 0;
            timer2Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
        }
        if(timer3 >= timer3Max) {
            //Debug.Log("THREE!");
            int rand3 = Mathf.RoundToInt(Random.Range(3f,6f));
            int rand1 = Mathf.RoundToInt(Random.Range(0,rand3));
            int rand2 = Mathf.RoundToInt(Random.Range(0,rand3));
            if(rand1 == rand2) {
                fuelPrefabNumber = Mathf.RoundToInt(Random.Range(0,2f));
                GameObject fuelInstance = Instantiate(fuelPrefabs[fuelPrefabNumber],instantiationPoints[2].position,Quaternion.identity) as GameObject;
                fuelInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,moveSpeed * Time.fixedDeltaTime);
            }
            else {
                int obstacleType = Mathf.RoundToInt(Random.Range(0,3f));
                GameObject obstacle = Instantiate(obstacles[obstacleType],instantiationPoints[2].position,Quaternion.identity) as GameObject;
                obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, moveSpeed * Time.fixedDeltaTime);
                //Debug.Log(obstacle.GetComponent<Rigidbody2D>().velocity);
            }
            timer3 = 0;
            timer3Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
        }
        if(timer4 >= timer4Max) {
            //Debug.Log("FOUR!");
            int rand3 = Mathf.RoundToInt(Random.Range(3f,6f));
            int rand1 = Mathf.RoundToInt(Random.Range(0,rand3));
            int rand2 = Mathf.RoundToInt(Random.Range(0,rand3));
            if(rand1 == rand2) {
                fuelPrefabNumber = Mathf.RoundToInt(Random.Range(0,2f));
                GameObject fuelInstance = Instantiate(fuelPrefabs[fuelPrefabNumber],instantiationPoints[3].position,Quaternion.identity) as GameObject;
                fuelInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,moveSpeed * Time.fixedDeltaTime);
            }
            else {
                int obstacleType = Mathf.RoundToInt(Random.Range(0,3f));
                GameObject obstacle = Instantiate(obstacles[obstacleType],instantiationPoints[3].position,Quaternion.identity) as GameObject;
                obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, moveSpeed * Time.fixedDeltaTime);
                //Debug.Log(obstacle.GetComponent<Rigidbody2D>().velocity);
            }
            timer4 = 0;
            timer4Max = Random.Range(minTimeToSpawn,maxTimeToSpawn);
        }
    }
}
