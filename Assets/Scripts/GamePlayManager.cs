using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{

    public GameObject originalPipe;
    public float pipeSpacing = 3f;
    public GameObject canvasGameOver;
    public Text textScore;
    public Text textBestScore;
    public int score = 0;
    public int best = 0;
    public float gapRange = 1.5f;
    public bool gameOver = false;

    public AudioSource audioScore;
    public AudioSource audioBest;
    public AudioSource audioBG;

    void Awake() {
        GenerateLevel();

        if (PlayerPrefs.HasKey("BEST"))
        {
            best = PlayerPrefs.GetInt("BEST");
        }
    }

    void Start() { }

    void Update() { }

    public void GenerateLevel() {
        for (int i = 0; i < 100; i++) {
            GameObject pipe = Instantiate(originalPipe);
            pipe.transform.position = new Vector3(i * pipeSpacing, Random.Range(-gapRange, gapRange), 0);
        }
    }

    public void GameOver() {
        gameOver = true;
        canvasGameOver.SetActive(true);
        textBestScore.text = PlayerPrefs.GetInt("BEST").ToString();
        audioBG.Stop();
    }

    public void AddScore() {
        if (gameOver) return;

        score++;
        textScore.text = score.ToString();
        audioScore.Play();

        if (score > best) {
            audioBest.Play();
            PlayerPrefs.SetInt("BEST", score);
            PlayerPrefs.Save();
        }

    }

    public void ResetBestScore() {
        PlayerPrefs.SetInt("BEST", 0);
        PlayerPrefs.Save();
    }

}
