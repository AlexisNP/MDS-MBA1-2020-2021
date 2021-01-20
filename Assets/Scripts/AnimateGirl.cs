using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(Rigidbody2D))]
public class AnimateGirl : MonoBehaviour {
    [Tooltip("Vitesse max en unités par secondes")]
    int MaxSpeed = 5;

    // Autres scripts
    SpriteRenderer spriteRenderer;
    Animator animator;
    Rigidbody2D rb;

    bool isMoving = false;

    // variables de mon instance
    Vector3 speed;

    // statics
    static readonly int Speed = Animator.StringToHash("Speed");
    static readonly int Roll = Animator.StringToHash("Roll");

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        isMoving = false;
        characterControls();
    }

    void characterControls() {
        var maxDistancePerFrame = MaxSpeed;
        Vector3 move = Vector3.zero;

        // RIGHT + LEFT
        if (Input.GetKey(KeyCode.RightArrow)) {
            isMoving = true;
            move += Vector3.right * maxDistancePerFrame;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            isMoving = true;
            move += Vector3.left * maxDistancePerFrame;
            spriteRenderer.flipX = true;
        }

        // UP + DOWN
        if (Input.GetKey(KeyCode.UpArrow)) {
            isMoving = true;
            move += Vector3.up * maxDistancePerFrame;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            isMoving = true;
            move += Vector3.down * maxDistancePerFrame;
        }

        // "Roll" action
        // if (animator.GetBool(Roll)) animator.ResetTrigger(Roll);
        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     animator.SetTrigger(Roll);
        // }

        animator.SetFloat(Speed, move.magnitude * 10f);
        setSpeed(move);
    }

    void setSpeed(Vector3 move) {
        rb.velocity = move;
    }
}