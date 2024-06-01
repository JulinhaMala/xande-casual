using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class two : MonoBehaviour
{
    public Text scoreText, scoreText2;
    public static two instance;
    private int score;
    public Text textoMelhorPontuacao;
    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }
    private void Start()
    {
        BestPoint.Pontuacao = 0;
    }
    private void Update()
    {
        this.scoreText.text = BestPoint.Pontuacao.ToString();
        this.scoreText2.text = BestPoint.Pontuacao.ToString();
        this.textoMelhorPontuacao.text = BestPoint.MelhorPontuacao.ToString();
    }
    public void ShowGameOver()
    {
        scoreText.enabled = false;
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void AddScore()
    {

    }

    /*public static int MelhorPontuacao
    {
        get
        {
            int melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao", 0);
            return melhorPontuacao;
        }
        set
        {
            if(value > MelhorPontuacao)
            {
                PlayerPrefs.SetInt("melhorPontuacao", value);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.instance.AddScore();
        }
    }*/
}