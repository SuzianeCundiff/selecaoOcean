using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;

    // Awake is called before Start.
    void Awake()
    {
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject); // if this gameController is not needed anymore, it destroys itself.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored(){
        if(gameOver){
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void BirdDied(){
        gameOverText.SetActive(true);
        gameOver = true;
    }

}
