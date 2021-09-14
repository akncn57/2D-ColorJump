using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        // Camera follow player.
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }    
    }
}
