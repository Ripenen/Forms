using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text _scoreText;
    private int _score;
    private void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    public void AddScore(int score)
    {
        _score += score;

        _scoreText.text = _score.ToString();
    }

    public void SetScore(int score)
    {
        _score = score;

        _scoreText.text = _score.ToString();
    }
    public int GetScore()
    {
        return _score;
    }
}
