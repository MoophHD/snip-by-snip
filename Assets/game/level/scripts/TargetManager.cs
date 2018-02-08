using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {
    public Transform container;
    private GameObject target;
    private int _id = 0;
    private List<GameObject> targets;

    void Awake() {
        targets = LevelReducer.instance.targets;
        target = LevelReducer.instance.target;
    }

    void OnEnable() {
        LevelReducer.onTargetAdd += (y) => { return addTarget(y); };
        LevelReducer.onTargetHit += (id) => { removeTarget(id);};
        State.onNewGame += clear;
    }

    void OnDisable() {
        LevelReducer.onTargetAdd -= (y) => { return addTarget(y); };
        LevelReducer.onTargetHit -= (id) => { removeTarget(id);};
        State.onNewGame -= clear;
    }

    GameObject addTarget(float y) {
        GameObject newTarget = Instantiate(target);
        newTarget.GetComponent<LevelTarget>().init(_id++, y);
        newTarget.GetComponent<Transform>().SetParent(container);

        targets.Add(newTarget);
    
        return newTarget;
    }

    void removeTarget(int id) {
        GameObject currTarget;
        for (int i = 0; i < targets.Count; i++) {
            currTarget = targets[i];
            if ( currTarget.GetComponent<LevelTarget>().id == id ) {
                targets.RemoveAt(i);
                Destroy(currTarget);
            }

        }
    }

    public void clear() {
        GameObject currTarget;
        for (int i = 0; i < targets.Count; i++) {
            currTarget = targets[i];
            targets.RemoveAt(i);
            Destroy(currTarget);
        }
    }
}