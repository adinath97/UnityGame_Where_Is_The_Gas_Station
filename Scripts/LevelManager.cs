using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject playGameCommand;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameOverBackground;
    [SerializeField] GameObject creditsText;
    [SerializeField] GameObject creditsBackground;
    
    [SerializeField] GameObject fuelLeftText;
    [SerializeField] GameObject milesCoveredText;
    [SerializeField] GameObject fuelAndMilesBackgroundImage;
    [SerializeField] float decreaseRateFactor = .5f;
    [SerializeField] GameObject introMessage;
    [SerializeField] GameObject introMessageImage;
    [SerializeField] GameObject bestScoreText;
    [SerializeField] GameObject bestScoreBackgroundImage;
    [SerializeField] GameObject title1Image;
    [SerializeField] GameObject title2Image;
    
    [SerializeField] AudioClip[] mySoundsAgain;
    [SerializeField] AudioSource myAudioSource;
    public static float fuelLeft = 100f;
    public static float miles = 0;
    public static bool gameOver, gamePlayed, clicked, loadedOnce;

    void Awake()
    {
        loadedOnce = false;
        clicked = false;
        gamePlayed = false;
        gameOver = true;
        gameOverText.SetActive(false);
        gameOverBackground.SetActive(false);
        fuelLeftText.SetActive(false);
        milesCoveredText.SetActive(false);
        introMessage.SetActive(false);
        bestScoreText.SetActive(false);
        introMessageImage.SetActive(false);
        fuelAndMilesBackgroundImage.SetActive(false);
        bestScoreBackgroundImage.SetActive(false);
        myAudioSource = this.GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        fuelLeftText.GetComponent<Text>().text = "FUEL: " + Mathf.RoundToInt(fuelLeft).ToString();
        milesCoveredText.GetComponent<Text>().text = "MILES: " + Mathf.RoundToInt(miles).ToString();
        bestScoreText.GetComponent<Text>().text = "BEST: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore",0f)) + " MILES";
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !clicked) {
            AudioClip clip = mySoundsAgain[0];
            myAudioSource.PlayOneShot(clip);
            clicked = true;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && !gamePlayed && !loadedOnce) {
            loadedOnce = true;
            gameOver = false;
            titleText.SetActive(false);
            playGameCommand.SetActive(false);
            title1Image.SetActive(false);
            title2Image.SetActive(false);
            creditsText.SetActive(false);
            creditsBackground.SetActive(false);
            fuelLeftText.SetActive(true);
            milesCoveredText.SetActive(true);
            introMessage.SetActive(true);
            bestScoreText.SetActive(true);
            introMessageImage.SetActive(true);
            fuelAndMilesBackgroundImage.SetActive(true);
            bestScoreBackgroundImage.SetActive(true);
            StartCoroutine(WaitAndDeleteIntroRoutine());
        }

        if(Input.GetKeyDown(KeyCode.Space) && gamePlayed) {
            fuelLeft = 100f;
            miles = 0f;
            AudioClip clip = mySoundsAgain[0];
            myAudioSource.PlayOneShot(clip);
            //Debug.Log("SOUND SHOULD PLAY");
            StartCoroutine(WaitAndLoadFresh());
        }
        if(!gameOver) {
            if(miles > 25 && miles < 50) {
            decreaseRateFactor = 1f;
            }
            if(miles > 50 && miles < 75) {
                decreaseRateFactor = 1.25f;
            }
            if(miles > 75 && miles < 100) {
                decreaseRateFactor = 1.5f;
            }
            if(miles > 100) {
                decreaseRateFactor = 1.75f;
            }
            if(Mathf.RoundToInt(miles) > PlayerPrefs.GetFloat("HighScore",0f)) {
                PlayerPrefs.SetFloat("HighScore",Mathf.RoundToInt(miles));
            }
            fuelLeft -= Time.deltaTime * decreaseRateFactor;
            fuelLeftText.GetComponent<Text>().text = "FUEL: " + Mathf.RoundToInt(fuelLeft).ToString();
            if(fuelLeft <= 0) {
                AudioClip clip = mySoundsAgain[1];
                myAudioSource.PlayOneShot(clip);
                player.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(WaitAndProgressRoutine());
                gameOver = true;
            }

            miles += Time.deltaTime;
            milesCoveredText.GetComponent<Text>().text = "MILES: " + Mathf.RoundToInt(miles).ToString();

            bestScoreText.GetComponent<Text>().text = "BEST: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore",0f)) + " MILES";
        }
        if(gameOver && gamePlayed) {
            clicked = false;
            //Debug.Log(clicked);
            fuelLeftText.SetActive(false);
            milesCoveredText.SetActive(false);
            introMessage.SetActive(false);
            bestScoreText.SetActive(false);
            introMessageImage.SetActive(false);
            fuelAndMilesBackgroundImage.SetActive(false);
            bestScoreBackgroundImage.SetActive(false);
            titleText.SetActive(true);
            playGameCommand.SetActive(false);
            gameOverText.SetActive(true);
            gameOverBackground.SetActive(true);
            title1Image.SetActive(true);
        }
    }

    IEnumerator WaitAndProgressRoutine() {
        yield return new WaitForSeconds(.5f);
        gamePlayed = true;
    }

    IEnumerator WaitAndDeleteIntroRoutine() {
        yield return new WaitForSeconds(4f);
        introMessage.SetActive(false);
        introMessageImage.SetActive(false);
    }

    IEnumerator WaitAndLoadFresh() {
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene("GameScene");
    }
}
