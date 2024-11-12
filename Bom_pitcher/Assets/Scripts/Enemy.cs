using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public GameObject bombPrefab; // 爆弾のプレハブ
    public Transform throwPoint; // 爆弾を投げる位置となるTransform
    public float throwForce = 10f; // 投げる力
    public float speed = 3f; // 敵の移動速度
    public float attackRange = 2f; // 攻撃範囲
    public float detectionRange = 15f; // プレイヤーを検知する範囲
    public Transform[] patrolPoints; // パトロールするポイント
    public float throwCooldown = 3f; // 爆弾を投げるクールダウン時間

    private int currentPatrolIndex = 0; // 現在のパトロールポイントのインデックス
    private float lastThrowTime; // 最後に爆弾を投げた時間
    [SerializeField] float detectionRadius = 15f; // 爆弾の検知範囲
    Rigidbody cpuRb; // CPUのRigidbody

    void Start()
    {
        cpuRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        AvoidBombs();

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // プレイヤーを攻撃する
            AttackPlayer();
        }
        else if (distanceToPlayer <= detectionRange)
        {
            // プレイヤーを追跡する
            FollowPlayer();

            // プレイヤーに爆弾を投げる
            if (Time.time - lastThrowTime >= throwCooldown)
            {
                ThrowBomb();
                lastThrowTime = Time.time;
            }
        }
        else
        {
            // パトロールする
            Patrol();
        }

        float move = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);
    }

     void AvoidBombs()
    {
        // 検知範囲内の全ての爆弾を検出
        Collider[] bombs = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Bomb"));

        if (bombs.Length > 0)
        {
            // 最も近い爆弾を探す
            Collider nearestBomb = bombs[0];
            float minDistance = Vector3.Distance(transform.position, nearestBomb.transform.position);

            foreach (var bomb in bombs)
            {
                float distance = Vector3.Distance(transform.position, bomb.transform.position);
                if (distance < minDistance)
                {
                    nearestBomb = bomb;
                    minDistance = distance;
                }
            }

            // 爆弾の反対方向に避ける
            Vector3 avoidanceDirection = (transform.position - nearestBomb.transform.position).normalized;
            cpuRb.velocity = avoidanceDirection * speed;
        }
        else
        {
            // 爆弾が検知範囲にない場合、停止する
            cpuRb.velocity = Vector3.zero;
        }
    }

    

    void FollowPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    void AttackPlayer()
    {
        // 攻撃ロジックをここに追加
        Debug.Log("Attacking the player");
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPatrolPoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPatrolPoint.position) < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }

        transform.LookAt(targetPatrolPoint);
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        Vector3 direction = (player.position - throwPoint.position).normalized;
        rb.AddForce(direction * throwForce, ForceMode.Impulse);
        Debug.Log("Throwing bomb at the player");
    }
}
