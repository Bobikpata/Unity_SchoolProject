using UnityEngine;

public class EnemyProjectile : Enemy //inherits from enemy script, damages every collision
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifeTime;
    private int directionX;
    private int directionY;


    public void SetDirection(int _directionX, int _directionY)
    {
        directionX = _directionX;
        directionY = _directionY;
        if (directionX == 1)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (directionX == -1)
        {
            transform.rotation = Quaternion.Euler(0,0,180);
        }

        if (directionY == 1)
        {
            transform.rotation = Quaternion.Euler(0,0,90);
        }

        if (directionY == -1)
        {
            transform.rotation = Quaternion.Euler(0,0,-90);
        }
        ActivateProjectile();
    }

    private void ActivateProjectile()
    {
        lifeTime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); //trigger OnTrigger from parent script (Enemy - TakeDamage)
        if(collision.tag != "Trap")
        {
            gameObject.SetActive(false); //if projectile collision, deactivates
        }
    }
}
