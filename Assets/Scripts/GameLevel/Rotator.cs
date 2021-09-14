using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;

    private void Update()
    {
        // Circle rotate move.
        transform.Rotate(0, 0, speed * Time.deltaTime);    
    }
}
