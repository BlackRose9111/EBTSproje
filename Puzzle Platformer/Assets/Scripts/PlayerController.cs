using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Iki oyuncumuzun hangisi olduðunu birbirinden ayýrt etmek için enum oluþturdum. -Baran
    /// </summary>
    public enum PlayerTipi
    {
        aydýnlýk,
        karanlýk
    }

    public PlayerTipi playerTipi;

    private Rigidbody2D rigid;

    //Oyuncunun Hareket hýzý
    public float speed = 15f;

    public float jumpRate = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(rigid);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void HorizontalMove(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.performed);

        if (ctx.performed)
        {
            rigid.AddForce(Vector2.up * jumpRate, ForceMode2D.Impulse);
        }
    }
}