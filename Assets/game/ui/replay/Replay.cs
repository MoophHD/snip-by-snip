using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour  {
    public Button btn;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(handleClick);
    }

    void handleClick()
    {
        Signals.newGame();
    }
}