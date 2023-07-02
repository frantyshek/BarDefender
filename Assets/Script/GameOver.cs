using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] PlayerController player;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateText()
    {
        text.text = "Score: " + player.score;
    }
}
