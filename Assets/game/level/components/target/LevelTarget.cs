using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LevelTarget : MonoBehaviour {
    public float height;
    void Awake() {
        height = GetComponent<CircleCollider2D>().bounds.max.y;
    }

    public void init(float y) {
                                    // half of the camera width
        // Vector3 newPos = new Vector3(Constants.instance.maxCameraBounds.x/2, y, transform.position.z);
        Vector3 newPos = new Vector3(0f, y, transform.position.z);
        GetComponent<Transform>().position = newPos;
    }
}