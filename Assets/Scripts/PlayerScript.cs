using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [Header("InputReferences")]
    [SerializeField] private InputActionReference movement;
    [SerializeField] private InputActionReference jump;

    [Header("Variables")]
    [SerializeField] private Vector2 dir;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float maxJumpImpulse;
    [SerializeField] private float jumpImpulse;
    [SerializeField] private bool isOnGround = false;
    [SerializeField] private PlayerRecollection cc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        maxSpeed = speed;
        maxJumpImpulse = jumpImpulse;
    }

    // Update is called once per frame
    void Update()
    {
        dir = movement.action.ReadValue<Vector2>();
        coinCounterCheck();

        
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(dir.x * speed, rb2d.linearVelocity.y);
    }

    private void OnEnable()
    {
        jump.action.started += Jump;

    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isOnGround)
        {
            rb2d.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }   
    }

    private void coinCounterCheck()
    {
        if (cc.coincounter == 10)
        {
            SpeedReduction();
            cc.coincounter = 0;
        }
    }

    private void SpeedReduction()
    {
        speed -= maxSpeed * 0.25f;
        jumpImpulse -= maxJumpImpulse * 0.30f;
    }


}
