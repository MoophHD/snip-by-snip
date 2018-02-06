using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheck : MonoBehaviour {
    public Transform myCamera;
    private const float checkDelta = 2.5f;
    private float distanceToGen;
    private float lastGenY;

    void Awake() {
        lastGenY = myCamera.position.y;
        distanceToGen = LevelReducer.instance.distanceToGen;
    }

    void Start() {
        InvokeRepeating("checkCamera", 0f, checkDelta);
    }

    void checkCamera() {
        if ( myCamera.position.y - lastGenY >= distanceToGen) {
            LevelReducer.gen();
            lastGenY = lastGenY + distanceToGen;
        }
    }
}

