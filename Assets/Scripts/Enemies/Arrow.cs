using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private string direction;
    [SerializeField] private AudioClip arrowShot;
    [SerializeField] private GameObject player;
    private float cooldownTimer;
    private int projectileDirectionX;
    private int projectileDirectionY;

    private void Attack()
    {
        cooldownTimer = 0; //reset timer after shoot

        projectiles[FindProjectile()].transform.position = firePoint.position;

        if (direction.ToLower() == "up")
        {
            projectileDirectionX = 0;
            projectileDirectionY = 1;
        }

        if (direction.ToLower() == "down")
        {
            projectileDirectionX = 0;
            projectileDirectionY = -1;
        }

        if (direction.ToLower() == "right")
        {
            projectileDirectionX = 1;
            projectileDirectionY = 0;
        }

        if (direction.ToLower() == "left")
        {
            projectileDirectionX = -1;
            projectileDirectionY = 0;
        }

        projectiles[FindProjectile()].GetComponent<EnemyProjectile>().SetDirection(projectileDirectionX,projectileDirectionY);
    }

    private int FindProjectile()
    {
        if (player.transform.position.x + 12 > firePoint.position.x && player.transform.position.x - 12 < firePoint.position.x && player.transform.position.y + 10 > firePoint.position.y && player.transform.position.y - 10 < firePoint.position.y)
        {
            SoundManager.instance.PlaySound(arrowShot);
        }
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy) //next not active projectile
            {
                return i;
            }
        }

        return 0; //first projectile
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown && (player.transform.position.x + 12 > firePoint.position.x && player.transform.position.x - 12 < firePoint.position.x))
        {
            Attack();
        }
    }
}
