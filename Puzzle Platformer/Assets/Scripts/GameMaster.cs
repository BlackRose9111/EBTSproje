using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int sceneCount;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Respawn(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(sceneCount);
            Time.timeScale = 1;
        }
    }
}