using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private GameObject gameMaster;

    public bool[] killTypes = new bool[2];

    // Start is called before the first frame update
    private void Awake()
    {
        gameMaster = GameObject.Find("Game Manager");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool tip = other.gameObject.GetComponent<PlayerController>().playerTipi;

        if ((tip && killTypes[0]) || (!tip && killTypes[1]))

        {
            gameMaster.GetComponent<GameMaster>().Respawn(other);
        }
    }
}