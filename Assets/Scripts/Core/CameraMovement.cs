using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Player camera
    [SerializeField] private Transform Player;
    [SerializeField] public Health playerHealth;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {

        //Camera follows player
        transform.position = new Vector3(Player.position.x + lookAhead, transform.position.y, transform.position.z);
        if (transform.position.y <= Player.position.y - 2 || transform.position.y >= Player.position.y + 2 && !playerHealth.dead) //changes camera also on y position while not dead + certain criteria
        {
            transform.position = new Vector3(Player.position.x + lookAhead, Player.position.y, transform.position.z);
        }
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
