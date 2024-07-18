using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
   void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameOver);
    }


    void GameOver()
    {
        SceneManager.LoadScene("StartScene");
    }
}
