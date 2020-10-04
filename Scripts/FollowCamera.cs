using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;

    private Vector3 offset = Vector3.back;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    void FixedUpdate()
    {
        Vector3 newPosition = player.position + offset;
        transform.position = newPosition;
    }
}
