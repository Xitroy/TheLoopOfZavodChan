using UnityEngine;

public class Action : MonoBehaviour
{
    private Player player;
    private SpriteRenderer eButtonImage;
    private SpriteRenderer progressbarImage;

    [Range(1, 15)]
    public float timeToComplete;
    private float timer;

    public bool actionStarted { get; private set; }
    public bool actionEnded { get; private set; }

    void Start()
    {
        player = FindObjectOfType<Player>();
        eButtonImage = GetComponentInChildren<Animation>().GetComponent<SpriteRenderer>();
        progressbarImage = GetComponentInChildren<SpriteRenderer>();

        eButtonImage.color = new Color(1, 1, 1, 0);
        progressbarImage.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        if (!actionEnded)
        {
            progressbarImage.color = new Color(1, 1, 1, 1 - Vector2.Distance(player.transform.position, transform.position) / 0.5f);

            if (Vector2.Distance(player.transform.position, transform.position) < 0.15)
            {
                if (!actionStarted)
                    eButtonImage.gameObject.GetComponent<Animation>().Play();

                if (Input.GetKeyDown(KeyCode.E))
                    actionStarted = true;

                if (actionStarted)
                {
                    player.movementBlocked = true;

                    timer += Time.deltaTime;
                    timer = Mathf.Clamp(timer, 0, timeToComplete);
                    progressbarImage.transform.localScale = new Vector3(Mathf.Lerp(0.025f, 0f, timer / timeToComplete), Mathf.Lerp(0.025f, 0f, timer / timeToComplete));
                    actionEnded = timer == timeToComplete ? true : false;
                }
                else
                    timer = 0;
            }
        }
        else
            player.movementBlocked = false;
    }
}
