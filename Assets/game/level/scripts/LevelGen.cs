using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {
    private const int MAX_ELEMS = 10;
    public Transform container;
    public GameObject target;
    private List<GameObject> targets = new List<GameObject>();

    private float distanceToGen;
    private const int genNum = 3;
    private float targetHeight;
    void OnEnable() {
        LevelReducer.onGen += gen;
    }

    void OnDisable() {
        LevelReducer.onGen -= gen;
    }

    void Awake() {
        distanceToGen = LevelReducer.instance.distanceToGen;
        GameObject firstTarget = appendTarget(distanceToGen * 2f);
        targetHeight = firstTarget.GetComponent<LevelTarget>().height;

        gen();
    }

    void gen() {
        for (int i = 0; i < genNum; i++) {
            GameObject lastTarget = targets[targets.Count - 1];
            float lastTargetPos  = lastTarget.transform.position.y;
            
            // float newTargetY = lastChildPos+ distanceToGen / genNum;
            float newTargetY = lastTargetPos  + distanceToGen / genNum;

            appendTarget(newTargetY);


            if (targets.Count > MAX_ELEMS) {
                // remove the oldest
                Destroy(targets[0]);
                targets.RemoveAt(0);
            }
        }
    }

    GameObject appendTarget(float y) {
        GameObject newTarget = Instantiate(target);
        newTarget.GetComponent<LevelTarget>().init(y);
        newTarget.GetComponent<Transform>().SetParent(container);

        targets.Add(newTarget);
    
        return newTarget;
    }
}