using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwForce = 10;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ThrowBomb();
        }
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, throwPoint.rotation);

        // // 爆弾に投げたオブジェクトの情報を設定
        // Bomb bombScript = bomb.GetComponent<Bomb>();
        // bombScript.thrower = gameObject;

        // 爆弾に力を加える
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        Vector3 throwDirection = Camera.main.transform.forward; // カメラの前方向に投げる
        bombRb.AddForce(throwDirection * throwForce, ForceMode.VelocityChange);
    }
}
