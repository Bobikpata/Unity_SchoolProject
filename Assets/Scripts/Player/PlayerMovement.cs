using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    public float checkpointPositionX;
    public float checkpointPositionY;
    private UIManager uiManager;
    [SerializeField] private AudioClip hurtSound;
    
    public void Awake() //when loaded
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("onwall",onWall() && !isGrounded());
        
        //otočení postavy
        
        if(horizontalInput> 0.01f)
        {
            transform.localScale = Vector2.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector2(-1,1);
        }

        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed,body.velocity.y); //movement

            if (onWall() && isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else {
                body.gravityScale = 2.5f;
            }

            if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                Jump();
            }
        }
        else {
            wallJumpCooldown += Time.deltaTime;
        }
    }
    private void Jump()
    {
        if (isGrounded())
        {
            //jump
            body.velocity = new Vector2(body.velocity.x,jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() &&  !isGrounded()) //wall jump
        {
            //Mathf.Sign -  if player is turned left: -1, if player is turned right: 1
            if (horizontalInput != Mathf.Sign(transform.localScale.x)) //is not sticking to the wall
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 11, 1); //jump away from the wall, Mathf.Sign negative to force jump away from wall
                transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), transform.localScale.y);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 4, 8); //walljump,  * 4 - how much pushed to the side, 8 how much pushed up
            }
            wallJumpCooldown = 0;
        }
    }

    public void GotHit() 
    {
        if (GetComponent<Health>().CheckHealth() > 0) // if dead, doesnt teleport
        {
            // if hit, teleports player to the position of a checkpoint
            SoundManager.instance.PlaySound(hurtSound);
            transform.position = new Vector2(checkpointPositionX, checkpointPositionY);
        }
        else
        {
            uiManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
        }
    }
    
    private bool isGrounded()
    {
        //boxcollider, creates a box that if collides with smth, returns true
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null; 
    }

    private bool onWall()
    {
        //boxcollider, creates a box that if collides with smth, returns true
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null; 
    }

}
