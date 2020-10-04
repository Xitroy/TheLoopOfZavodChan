using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CheckList : MonoBehaviour
{
    private bool initialized;
    private Action[] actions;

    void Start()
    {
        actions = FindObjectsOfType<Action>();
    }

    void Update()
    {
        if (!initialized)
        {
            var itemPrefab = transform.GetChild(1).gameObject;

            for (int count = 0; count < actions.Length; count++)
            {
                var item = count == 0 ? itemPrefab : Instantiate(itemPrefab, transform);
                item.name = actions[count].name;
                var titleText = item.GetComponentInChildren<TMPro.TMP_Text>();
                titleText.text = actions[count].name;
            }

            initialized = true;
        }

        for (int count = 0; count < actions.Length; count++)
        {
            if (actions[count].actionEnded)
            {
                GameObject.Find("UI/To-Do list/" + actions[count].name + "/Checkbox/Done").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
}
