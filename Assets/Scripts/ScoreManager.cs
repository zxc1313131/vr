using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    private int totalScore = 0; //общее кол-во очков = 0

    public Text scoreText; //добавление текствого ввода

    private void Start()
    {
        //Подписка на событие выстрела
        FireManager.onTargetHit += HandleTargetHit;
    }

    private void HandleTargetHit(string targetTag, int points) //Обратботка попадания
    {
        
        totalScore += points; //Общее кол-во очков = кол-ву за попадание
        UpdateUI(); //срабатывает функция

    }
    
    private void UpdateUI() //Функция обновления UI
    {
        if (scoreText != null) //если поле пустое, значит выводит:
        {
            scoreText.text = $"Score: {totalScore}";
        }
    }
}
