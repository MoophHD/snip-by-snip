using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {
    private float distanceToGen;
    private float targetHeight;
    private List<GameObject> targets;
    private int maxTargets;
    private GameObject target;
    private float playerJumpHeight = 1.5f;
    public float targetSpaceHeight;
    public int maxGenNum;
    void OnEnable() {
        LevelReducer.onGen += gen;
    }

    void OnDisable() {
        LevelReducer.onGen -= gen;
    }

    void Awake() {
        target = LevelReducer.instance.target;
        targets = LevelReducer.instance.targets;
        maxTargets = LevelReducer.instance.maxTargets;

        distanceToGen = LevelReducer.instance.distanceToGen;

        GameObject firstTarget = LevelReducer.targetAdd(distanceToGen * 2f);
        targetHeight = firstTarget.GetComponent<LevelTarget>().height;

        maxGenNum = (int) (distanceToGen / (playerJumpHeight * 1.25));
        targetSpaceHeight = playerJumpHeight * 1.1f;
        gen();
    }

        // sticky random / markovs chains, sorta
        //                                   to 1, to 2, to 3
    private static float[] space1 = new float[] {0.7f, 0.2f, 0.1f};
    private static float[] space2 = new float[] {0.20f, 0.50f, 0.30f};
    private static float[] space3 = new float[] {0.40f, 0.20f, 0.40f};
    private int lastSpace = 1;

    int getHeightCount() {  
        // [0..1]
        float randi = Random.value;
        int newSpace = 0;
        float[] space;

        if (lastSpace == 1) {
            space = space1;
        } else if (lastSpace == 2) {
            space = space2;
        } else {
            space = space3;
        }

        float tempoVal = 0f;
        for (int i = 0; i < space.Length; i++) {
            tempoVal += space[i];
            if (randi < tempoVal) {
                newSpace = i + 1;
                break;
            }
        }

        lastSpace = newSpace;
        return newSpace;
    }

    private float shiftMin = -0.05f;
    private float shiftMax = 0.25f;
    
    void gen() {
        int genNum = Random.Range(Mathf.Max(1, maxGenNum - 1), maxGenNum + 1);
        
        for (int i = 0; i < genNum; i++) {
            GameObject lastTarget = targets[targets.Count - 1];
            float lastTargetPos  = lastTarget.transform.position.y;
            
            // float newTargetY = lastChildPos+ distanceToGen / genNum;
            float newTargetY = lastTargetPos  +  targetSpaceHeight * getHeightCount();

            newTargetY+= Random.Range(shiftMin, shiftMax);

            LevelReducer.targetAdd(newTargetY);

            if (targets.Count > maxTargets) {
                // remove the oldest
                Destroy(targets[0]);
                targets.RemoveAt(0);
            }
        }
    }
}