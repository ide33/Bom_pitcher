using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionDelay = 3f; // 爆発までの遅延時間
    public float explosionRadius = 5f; // 爆発の半径
    public float explosionForce = 700f; // 爆発の力
    public int damage = 50; // 爆発によるダメージ

    public GameObject explosionEffect; // 爆発のエフェクト

    void Start()
    {
        Invoke("Explode", explosionDelay);
    }

    void Explode()
    {
        // 爆発エフェクトの生成
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // 爆発範囲内のすべてのコライダーを取得
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            // Rigidbodyを持つオブジェクトに力を加える
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // ダメージ処理
            PlayerHealth playerHealth = nearbyObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        // 爆弾オブジェクトを破壊する
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // シーンビューで爆発範囲を可視化
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
