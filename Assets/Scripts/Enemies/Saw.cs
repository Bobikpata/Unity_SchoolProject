using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] public float moveDistance;
    [SerializeField] public float speed;
    [SerializeField] public float damage;
    [SerializeField] public string direction;
    private bool movingLeft;
    private float leftEdge;
    private float rigthEdge;

    public void Awake()
    {
        if (direction == "horizontal")
        {
            leftEdge = transform.position.x - moveDistance;
            rigthEdge = transform.position.x + moveDistance;
        }

        else if (direction == "vertical")
        {
            leftEdge = transform.position.y - moveDistance;
            rigthEdge = transform.position.y + moveDistance;
        }
    }

    public void Update()
    {
        if (direction == "horizontal")
        {
            if (movingLeft)
            {
                if (transform.position.x > leftEdge) //moving left, not hit the edge yet
                {
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                }
                else
                {
                    movingLeft = false;
                }
            }
            else
            {
                if (transform.position.x < rigthEdge) ////moving right, not hit the right yet
                {
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                }
                else
                {
                    movingLeft = true;
                }
            }
        }

        else if(direction == "vertical")
        {
            if (movingLeft)
            {
                if (transform.position.y > leftEdge) //moving left, not hit the edge yet
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y- speed * Time.deltaTime);
                }
                else
                {
                    movingLeft = false;
                }
            }
            else
            {
                if (transform.position.y < rigthEdge) ////moving right, not hit the right yet
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
                }
                else
                {
                    movingLeft = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            collision.GetComponent<PlayerMovement>().GotHit();
        }
    }
}
