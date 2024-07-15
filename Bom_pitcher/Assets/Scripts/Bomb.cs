using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionDelay = 3f;  // 爆発までの遅延時間
    public float explosionRadius = 5f;  // 爆発の半径
    public float explosionForce = 700f;  // 爆発の力
    public int damage = 50;  // 爆発のダメージ
    public GameObject explosionEffect;  // 爆発のエフェクトプレハブ

    private float countdown;
    private bool hasExploded = false;

    void Start()
    {
        countdown = explosionDelay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // 爆発エフェクトの生成
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // 周囲のオブジェクトを取得
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            // Rigidbodyに爆発力を適用
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // ダメージを適用
            PlayerHealth playerHealth = nearbyObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // 敵キャラクターにもダメージを適用
            EnemyHealth enemyHealth = nearbyObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }

        // 爆弾オブジェクトを破壊
        Destroy(gameObject);
    }
}
