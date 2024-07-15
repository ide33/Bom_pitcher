using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // 最大HP
    public int currentHealth;    // 現在のHP
    public Slider healthSlider;  // HPゲージ

    void Start()
    {
        // ゲーム開始時に最大HPで初期化
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        if (healthSlider.value <= 0)
        {
            GameOver();
        }
    }

    // HPを減らす関数
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthUI();
    }

    // HPゲージを更新する関数
    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    void GameOver()
    {
        // ゲームオーバーシーンに移行
        SceneManager.LoadScene("GameOverScene");
    }
}
