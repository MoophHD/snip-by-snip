using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LevelTarget : MonoBehaviour {
    [HideInInspector]
    public float height;
    [HideInInspector]
    public int id;
    void Awake() {
        height = GetComponent<CircleCollider2D>().bounds.max.y;
    }

    public void init(int targetId, float y) {
        id = targetId;
                                    // half of the camera width
        // Vector3 newPos = new Vector3(Constants.instance.maxCameraBounds.x/2, y, transform.position.z);
        Vector3 newPos = new Vector3(0f, y, transform.position.z);
        GetComponent<Transform>().position = newPos;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "player") {
            LevelReducer.targetHit(id);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "bottomPad") {
            State.newGame();
        }
    }
}