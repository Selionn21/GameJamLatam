using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("InputReferences")]
    [SerializeField] private InputActionReference movement;
    [SerializeField] private InputActionReference jump;

    [Header("Movimiento")]
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private float jumpImpulse;

    private float baseSpeed;
    private float baseJump;

    [Header("Suelo")]
    [SerializeField] private bool isOnGround;

    [Header("Comida")]
    [SerializeField] private PlayerRecollection cc;
    [SerializeField] private int foodPerLevel = 10; // configurable
    [SerializeField] private int currentLevel = 0;  // 0 a 3

    [Header("Multiplicadores por nivel (4 fases)")]
    [SerializeField] private float[] speedMultiplier = { 1f, 0.8f, 0.6f, 0.4f };
    [SerializeField] private float[] jumpMultiplier = { 1f, 0.85f, 0.7f, 0.5f };

    [Header("Animación")]
    [SerializeField] private Animator animator;
    [SerializeField] private string animParameter = "FatLevel";

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        baseSpeed = speed;
        baseJump = jumpImpulse;
        isOnGround = true;

        ApplyLevel();
    }

    private void Update()
    {
        CheckFoodProgress();
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(speed, rb2d.linearVelocity.y);
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
            isOnGround = false;
            StartCoroutine(SaltoCd());
        }
    }

    IEnumerator SaltoCd()
    {
        yield return new WaitForSeconds(1);
        isOnGround = true;
    }

    private void CheckFoodProgress()
    {
        if (cc.coincounter >= foodPerLevel)
        {
            cc.coincounter = 0;

            if (currentLevel < 3) 
            {
                currentLevel++;
                ApplyLevel();
            }
        }
    }

    private void ApplyLevel()
    {
        speed = baseSpeed * speedMultiplier[currentLevel];
        jumpImpulse = baseJump * jumpMultiplier[currentLevel];

        if (animator != null)
        {
            animator.SetInteger(animParameter, currentLevel);
        }
    }
}