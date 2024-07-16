using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public GameObject bombPrefab; // 爆弾のPrefab
    public float throwDistance = 10f; // 爆弾を投げる距離
    public float throwCooldown = 2f; // 爆弾を投げるクールダウン時間

    private UnityEngine.AI.NavMeshAgent agent; // NavMeshAgent
    private float nextThrowTime = 0f; // 次に爆弾を投げる時間

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        // プレイヤーに向かって移動
        agent.SetDestination(player.position);

        // プレイヤーに近づいたら爆弾を投げる
        if (Vector3.Distance(transform.position, player.position) <= throwDistance)
        {
            TryThrowBomb();
        }
    }

    void TryThrowBomb()
    {
        if (Time.time >= nextThrowTime)
        {
            // 爆弾を投げる
            ThrowBomb();

            // 次に爆弾を投げるまでのクールダウン時間を設定
            nextThrowTime = Time.time + throwCooldown;
        }
    }

    void ThrowBomb()
    {
        // プレイヤーの方向に爆弾を投げる
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Vector3 direction = (player.position - transform.position).normalized;
        bomb.GetComponent<Rigidbody>().AddForce(direction * 500f); // Forceの強さは調整可能
    }
}
