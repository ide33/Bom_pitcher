using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
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
            GameClear();
        }
    }

    // HPを減らす関数
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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

    void GameClear()
    {
        // ゲームオーバーシーンに移行
        SceneManager.LoadScene("ClearScene");
    }
}
