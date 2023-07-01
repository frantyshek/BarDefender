using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barier : MonoBehaviour
{

    [SerializeField] int health;
    [SerializeField] Slider slider;
    [SerializeField] GameObject gameOverScreen;

    void Start()
    {
        Time.timeScale = 1f;
        this.slider.maxValue = health;
        this.slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;
        this.slider.value = health;
        if(health <= 0)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
