using UnityEngine;

public class ParallaxShader : MonoBehaviour
{
    public float speedMultiply = 1;
    public Vector2 direction = Vector2.right;

    private string id = "_TextureOffset";

    private Rigidbody2D player;
    private Material material;
    private Vector2 delta;

    private void Awake() => player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    private void Start() => material = GetComponent<SpriteRenderer>().material;
    private void OnEnable() => delta = Time.fixedDeltaTime * speedMultiply * 0.1f * direction;

    private void FixedUpdate()
    {
        Vector2 movement = player.linearVelocity * delta;
        if (movement == Vector2.zero) return;

        material.SetVector(id, (Vector2)material.GetVector(id) + movement);
    }

}
