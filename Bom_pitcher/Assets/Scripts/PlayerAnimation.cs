using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Animatorコンポーネントの取得
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 移動キーが押されているかチェック
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        animator.SetBool("isRun", isMoving);

        // 攻撃ボタン（Space）が押されたかチェック
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("ThrowTrigger");
        }
    }
}
