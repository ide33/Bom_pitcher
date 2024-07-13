using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveDirectionY = transform.position.y;
        float moveDirectionX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveDirectionZ = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;
        move.y = moveDirectionY;

        controller.Move(move * Time.deltaTime);
    }
}
