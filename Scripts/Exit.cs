using UnityEngine;

public class Exit : MonoBehaviour
{
    private Action action;

    void Start()
    {
        action = GetComponentInChildren<Action>();
    }

    void Update()
    {
        if (action.actionEnded)
        {
            Application.Quit();
        }
    }
}
