using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;
    private Vector2 direction;
    private Vector2 mousePosition;

    [Range(0.1f, 1f)]
    public float speed = 0.5f;

    public bool movementBlocked;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (!movementBlocked)
            rb.MovePosition(rb.position + speed * direction * Time.fixedDeltaTime);
    }
}
