using UnityEngine;

public class CustomAnimationController : MonoBehaviour
{
    public Sprite[] walkFrames; // Frames for walking animation
    public Sprite jumpFrame; // Single frame for jumping
    private SpriteRenderer spriteRenderer;
    public float framesPerMeter = 4;

    public Rigidbody2D rb;
    public ManController manController; // Reference to the ManController script

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateAnimationFrame();
    }

    private void UpdateAnimationFrame()
    {
        if (!manController.IsGrounded) // Access the IsGrounded property
        {
            spriteRenderer.sprite = jumpFrame;
            return;
        }

        // Flip sprite based on movement direction
        if (rb.velocity.x > 0.1f)
        {
            spriteRenderer.flipX = false;

            // Change frame based on X position
            int frameIndex = Maths.mod(Mathf.FloorToInt(framesPerMeter * transform.position.x), walkFrames.Length);
            spriteRenderer.sprite = walkFrames[frameIndex];
        }
        else if (rb.velocity.x < -0.1f)
        {
            spriteRenderer.flipX = true;

            // Change frame based on X position
            int frameIndex = Maths.mod(Mathf.FloorToInt(-framesPerMeter * transform.position.x), walkFrames.Length);
            spriteRenderer.sprite = walkFrames[frameIndex];
        }
    }
}
