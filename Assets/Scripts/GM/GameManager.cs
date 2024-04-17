using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI ScoreText;
    [Space]
    public int Score;
    public float Speed;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ScoreUpdate(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
    }
}
