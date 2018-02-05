using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTarget : MonoBehaviour {
    public void init(float y) {
                                    // half of the camera width
        Vector3 newPos = new Vector3(Constants.instance.maxCameraBounds.x/2, y, transform.position.z);
        GetComponent<Transform>().position = newPos;
    }
}