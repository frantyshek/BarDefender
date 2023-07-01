using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barier : MonoBehaviour
{

    [SerializeField] int health;
    [SerializeField] Slider slider;
    [SerializeField] GameObject gameOverScreen;

    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
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
            audio.Play();
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
