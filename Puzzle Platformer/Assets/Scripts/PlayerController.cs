using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Iki oyuncumuzun hangisi oldu�unu birbirinden ay�rt etmek i�in enum olu�turdum. -Baran
    /// </summary>
    public enum PlayerTipi
    {
        ayd�nl�k,
        karanl�k
    }

    public PlayerTipi playerTipi;

    private Rigidbody2D rigid;

    //Oyuncunun Hareket h�z�
    public float speed = 15f;

    public float jumpRate;
    private float movementHorizontal;
    private float movementVertical;

    public string horizontalMotionType;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        horizontalMotionType = GetHorizontalMotionType();
    }

    private string GetHorizontalMotionType()
    {
        if (playerTipi == PlayerTipi.ayd�nl�k)
        {
            return "First";
        }
        else
        {
            return "Second";
        }
    }

    // Update is called once per frame
    private void Update()
    {
        movementHorizontal = Input.GetAxisRaw(horizontalMotionType);
    }

    private void FixedUpdate()
    {
        if (MathF.Abs(movementHorizontal) == 1)
        {
            Debug.Log(movementHorizontal);
            rigid.AddForce(new Vector2(movementHorizontal * speed, 0f), ForceMode2D.Force);
        }
    }

    //public void HorizontalMove(InputAction.CallbackContext ctx)
    //{
    //    Debug.Log(ctx);
    //}

    //public void Jump(InputAction.CallbackContext ctx)
    //{
    //    Debug.Log(ctx.performed);

    //    if (ctx.performed)
    //    {
    //        rigid.AddForce(Vector2.up * jumpRate, ForceMode2D.Impulse);
    //    }
    //}
}