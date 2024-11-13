using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool gameIsActive;
    public GameObject mainMenu;
    private float spawnRate = 3.0f;
    public GameObject restartGame;
    private int score;

    // score ui
    public GameObject scoreUI; 
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        restartGame.SetActive(false);
        scoreUI.SetActive(false);
    }

    IEnumerator SpawnTargets()
    {

        while (gameIsActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int indexCount = Random.Range(0, targets.Count);
            Instantiate(targets[indexCount]);
        }
    }

    public void GameStart(int setLevel)
    {
        gameIsActive = true;
        score = 0;
        spawnRate /= setLevel;
        mainMenu.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(true);
        StartCoroutine(SpawnTargets());
    }

    public void GameOver()
    {
        gameIsActive = false;
        scoreUI.SetActive(false);
        StartCoroutine(RestartGame());

    }

    IEnumerator RestartGame()
    { 
        restartGame.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseScore(int pointValue)
    {
        score += pointValue;
        UpdateScore(score);
    }

    public void DecreaseScore(int pointValue)
    { 
        score -= pointValue;
        UpdateScore(score);
    }

    public int GetScore()
    {
        return score; 
    }
    private void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
}
