using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneButtonController : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        //Startボタンが押されたら
        if (CompareTag("Start"))
        {
            SceneManager.LoadScene("GameScene");
        }

        //Clearボタンが押されたら
        if (CompareTag("Clear"))
        {
            SceneManager.LoadScene("StartScene");
        }

        //GameOverボタンが押されたら
        if (CompareTag("GameOver"))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
