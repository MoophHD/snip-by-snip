using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {
    private float distanceToGen;
    private const int genNum = 3;
    private float targetHeight;
    private List<GameObject> targets;
    private int maxTargets;
    private GameObject target;

    void Awake() {
        target = LevelReducer.instance.target;
        targets = LevelReducer.instance.targets;
        maxTargets = LevelReducer.instance.maxTargets;

        distanceToGen = LevelReducer.instance.distanceToGen;

        GameObject firstTarget = LevelReducer.targetAdd(distanceToGen * 2f);
        targetHeight = firstTarget.GetComponent<LevelTarget>().height;

        gen();
    }

    void OnEnable() {
        LevelReducer.onGen += gen;
    }

    void OnDisable() {
        LevelReducer.onGen -= gen;
    }
    
    void gen() {
        for (int i = 0; i < genNum; i++) {
            GameObject lastTarget = targets[targets.Count - 1];
            float lastTargetPos  = lastTarget.transform.position.y;
            
            // float newTargetY = lastChildPos+ distanceToGen / genNum;
            float newTargetY = lastTargetPos  + distanceToGen / genNum;

            LevelReducer.targetAdd(newTargetY);

            if (targets.Count > maxTargets) {
                // remove the oldest
                Destroy(targets[0]);
                targets.RemoveAt(0);
            }
        }
    }
}