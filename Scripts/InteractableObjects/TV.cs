using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class TV : MonoBehaviour
{
    private Action action;
    private Light2D light2d;

    private float timer;

    void Start()
    {
        action = GetComponentInChildren<Action>();
        light2d = GetComponent<Light2D>();
    }

    void Update()
    {
        if (action.actionEnded)
        {
            if (timer > 0.15f)
            {
                light2d.intensity = Random.Range(0.25f, 0.5f);
                timer = 0;
            }
            else
                timer += Time.deltaTime;
        }
    }
}
