using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearController : MonoBehaviour
{
   void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameClear);
    }


    void GameClear()
    {
        SceneManager.LoadScene("StartScene");
    }
}
