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
    public bool playerTipi = true;

    private Rigidbody2D rigid;

    //Oyuncunun Hareket hýzý
    public float speed;

    public ControlScheme playerInput;

    //Zýplama oraný
    public float jumpRate;

    public bool OnGround = false;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        playerInput = new ControlScheme();
    }

    /// <summary>
    /// Hangi oyuncu kontrol sistemini kullanacaðýz
    /// </summary>
    public void GetMotionType()
    {
        Debug.Log(playerTipi);
        if (playerTipi)
        {
            playerInput.Player2.Disable();
            playerInput.Player1.Enable();
            playerInput.Player1.Jump.performed += Jump;
        }
        else
        {
            playerInput.Player1.Disable();
            playerInput.Player2.Enable();
            playerInput.Player2.JumpPlayer2.performed += Jump;
        }
    }

    /// <summary>
    /// yere temas etip etmediðimizi trigger olarak belirlenen bir collider ile belirliyoruz
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnGround = true;
    }

    private void FixedUpdate()
    {
        //sað sol hareket

        float horizontalSpeed = (playerInput.Player1.Walk.ReadValue<float>() + playerInput.Player2.Walk.ReadValue<float>()) * speed;
        rigid.velocity = new Vector2(horizontalSpeed, rigid.velocity.y);
    }

    /// <summary>
    /// Zýplama haraketi için gerekli fonksiyon
    /// </summary>
    /// <param name="ctx"></param>
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (OnGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpRate);
            OnGround = false;
        }
    }
}