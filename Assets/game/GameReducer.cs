using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReducer : MonoBehaviour {
    public Core playerCore;
    public CameraMovement cameraMovement;

    void OnEnable() {
        State.onNewGame += reset;
    }
    void OnDisable() {
        State.onNewGame -= reset;
    }

    
    void Update() {
         if (Input.GetMouseButtonDown(0) && State.instance.isGameFrozen ){
             //unfrize
             State.unfreeze();
         }
    }

    void reset() {
        playerCore.resetPos();
        cameraMovement.resetPos();
    }
}