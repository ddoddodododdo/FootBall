using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Team : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject spawnPoint;
    public TextMeshProUGUI scoreText;

    [HideInInspector]
    public int point;
    [HideInInspector]
    public int id;

    private void Start()
    {
        point = 0;
        SetScoreText();
    }

    //∞Ò¿Œ
    public void UpScore()
    {
        point++;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "" + point;
    }
}
