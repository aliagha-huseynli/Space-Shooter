using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randomPos;
    public float startWait;
    public float createWait;
    public float loopWait;
    public Text Score;
    public Text Game_Over;
    public Text playAgainText;
    bool gameOverControl;
    bool playAgainControl;

    int score;

    void Start()
    {
        score = 0;
        Score.text = "score = " + score;
        score = 0;
        StartCoroutine(create());    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playAgainControl)
        {
            SceneManager.LoadScene("level 1");
            //Debug.Log("Play Again");
        }
    }

    IEnumerator create()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {            
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(createWait);
            }

            if (gameOverControl)
            {
                playAgainText.text = "Press R to try again";
                playAgainControl = true;
                break;
            }

            yield return new WaitForSeconds(loopWait);


        }
    }

    public void AddScore(int plusScore)
    {
        score += plusScore;
        Score.text = "score = " + score;
        //Debug.Log(score);
    }

    public void gameOver()
    {
        Game_Over.text = "Game Over";
        gameOverControl = true;
        //Debug.Log("Game Over");
    }
        

        

    
}
