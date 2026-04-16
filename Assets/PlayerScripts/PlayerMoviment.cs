
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMoviment : MonoBehaviour
{
    [Header("Player Component References")]

    Vector3 playerScale;
    public SpriteRenderer srPlayer;
    public Rigidbody2D rb;

    [Header("Player Settings")]

    public bool IsfacingRight = true;
    public float speed;
    public float jumpingPower;

    [Header("Grounding")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;

    public float horizontal;

    private WeaponSistem weapon;

private void Start()
    {
        weapon = GetComponentInChildren<WeaponSistem>();
    }

    public void Update()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        FlipPlayer();
    }
    
    #region PLAYER_CONTROLS
    
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
    }

    public bool IsGrounded()
    {
        // return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f,0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    #endregion

    public void FlipPlayer()
    {
        if(weapon.angle > -90 && weapon.angle < 90)
        {
            srPlayer.flipX = false;
        }
        else
        {
            srPlayer.flipX = true;
        }  
    }
}
      

