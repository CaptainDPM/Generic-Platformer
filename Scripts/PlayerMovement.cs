using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private AudioClip jumpSound;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private float jumpCooldown;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();

            if (Input.GetKeyDown(KeyCode.Space))
                SoundManager.instance.PlaySound(jumpSound);
        }

        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    void Jump()
    {
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.05f, groundLayer);
        return raycastHit.collider != null;
    }

}
