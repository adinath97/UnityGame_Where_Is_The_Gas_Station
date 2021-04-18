using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float padding = 1f;
    [SerializeField] List<Transform> playerNodes = new List<Transform>();
    [SerializeField] AudioClip[] mySounds;
    AudioSource myAudioSource;
    float xMin, xMax, yMin, yMax, deltaX, deltaY, newXPos, newYPos;
    int currentNode;
    bool movementDone;

    
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = this.GetComponent<AudioSource>();
        moveSpeed = 4f;
        currentNode = 0;
        transform.position = playerNodes[currentNode].position;
        movementDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!LevelManager.gameOver) {
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                if(currentNode < 3 && LevelManager.fuelLeft >= 10f) {
                    LevelManager.fuelLeft -= 10f;
                    currentNode++;
                    movementDone = false;
                    RotatePlayer.ChangeCurrentAngle(Quaternion.Euler(0,0,-120f));
                }
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                if(currentNode > 0 && LevelManager.fuelLeft >= 10f) {
                    LevelManager.fuelLeft -= 10f;
                    currentNode--;
                    movementDone = false;
                    RotatePlayer.ChangeCurrentAngle(Quaternion.Euler(0,0,-60f));
                }
            }
            if(!movementDone) {
                Move(currentNode);
            }
            if(LevelManager.miles % 10 == 0) {
                moveSpeed += .1f;
            }
        }
    }

    public void Move(int currentNode) {
        var targetPosition = playerNodes[currentNode].transform.position;
        var movementThisFrame = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(
            transform.position,
            playerNodes[currentNode].transform.position,
            movementThisFrame);
        if(transform.position == targetPosition) {
            RotatePlayer.ChangeCurrentAngle(Quaternion.Euler(0,0,-90f));
            movementDone = true;
        }
        /*
        if(currentNode <= playerNodes.Count - 1) {
            var targetPosition = playerNodes[currentNode].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                transform.position,
                playerNodes[currentNode].transform.position,
                movementThisFrame);
            if(transform.position == targetPosition) {
                currentNode++;
            }
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fuel10") {
            AudioClip clip = mySounds[0]; 
            myAudioSource.PlayOneShot(clip);
            LevelManager.fuelLeft += 10f;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Fuel20") {
            AudioClip clip = mySounds[0]; 
            myAudioSource.PlayOneShot(clip);
            LevelManager.fuelLeft += 20f;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Fuel30") {
            AudioClip clip = mySounds[0]; 
            myAudioSource.PlayOneShot(clip);
            LevelManager.fuelLeft += 30f;
            Destroy(other.gameObject);
        }
        else {
            AudioClip clip = mySounds[1]; 
            myAudioSource.PlayOneShot(clip);
            this.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(WaitAndProgressRoutine());
            LevelManager.gameOver = true;
        }
    }

    IEnumerator WaitAndProgressRoutine() {
            yield return new WaitForSeconds(.5f);
            LevelManager.gamePlayed = true;
            LevelManager.fuelLeft = 100f;
            LevelManager.miles = 0f;
            Destroy(this.gameObject);
    }
}
