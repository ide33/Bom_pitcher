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
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
