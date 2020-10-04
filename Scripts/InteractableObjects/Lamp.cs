using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Lamp : MonoBehaviour
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
            if (timer > 1f)
            {
                timer = 1f;
            }
            else
                timer += Time.deltaTime;

            light2d.intensity = Mathf.Lerp(0f, 0.5f, timer);
        }
    }
}