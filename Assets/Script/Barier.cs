using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barier : MonoBehaviour
{

    [SerializeField] int health;
    [SerializeField] Slider slider;
    [SerializeField] GameObject gameOverScreen;

    [SerializeField] AudioSource audioS;
    [SerializeField] AudioSource audioEnd;

    private void Awake()
    {
    }

    void Start()
    {
        Time.timeScale = 1f;
        this.slider.maxValue = health;
        this.slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;
        this.slider.value = health;
        if(health <= 0)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            audioS.Play();
            audioEnd.Play();
            gameOverScreen.GetComponent<GameOver>().UpdateText();
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
