using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {
    private Transform tr;
    private Vector3 pos;
    private float shift;
    void Awake() {
        tr = GetComponent<Transform>();
    }
    void Update() {
        pos = tr.position;
        shift = Constants.instance.scrollingSpeed * Time.deltaTime;
        // tr.position = new Vector3(pos.x, pos.y + shift, pos.z);
    }
}
