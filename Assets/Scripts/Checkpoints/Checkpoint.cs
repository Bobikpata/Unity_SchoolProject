using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float checkpointPositionX;
    public float checkpointPositionY;

    private Animator anim;
    private PlayerMovement player;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            checkpointPositionX = transform.position.x;
            checkpointPositionY = transform.position.y;
            player.checkpointPositionX = checkpointPositionX;
            player.checkpointPositionY = checkpointPositionY;
            anim.SetTrigger("Checkpoint");
            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Checkpoint")) // checks if animation is playing
            {
                transform.position = new Vector2(transform.position.x, transform.position.y+0.5f);
            }
        }
    }

    public float Check_CheckpointPositionX()
    {
        return checkpointPositionX;
    }

    public float Check_CheckpointPositionY()
    {
        return checkpointPositionY;
    }
}
