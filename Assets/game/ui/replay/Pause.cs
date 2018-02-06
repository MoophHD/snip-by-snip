using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour  {
    public Button btn;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(handleClick);
    }

    void handleClick()
    {
        if (State.instance.isGameFrozen) {
            State.unfreeze();
        } else {
            State.freeze();
        }
    }
}