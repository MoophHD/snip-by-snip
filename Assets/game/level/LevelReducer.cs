using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReducer : MonoBehaviour {

    private static LevelReducer _instance;
	public static LevelReducer instance {
        get {
            return _instance;
        }
	}

 	public delegate void onGenDel();
    public static event onGenDel onGen;
    public static void gen() {onGen();}

    public delegate GameObject onTargetAddDel(float y);
    public static event onTargetAddDel onTargetAdd;
    public static GameObject targetAdd(float y) { return onTargetAdd(y);}


    public delegate void onTargetHitDel(int id);
    public static event onTargetHitDel onTargetHit;
    public static void targetHit(int id) {onTargetHit(id);}

 
    // level gen frequency
    private float _distanceToGen;
    public float distanceToGen {
    get {
        return _distanceToGen;
        }
    }
    private int _maxTargets;
    public int maxTargets {
    get {
        return _maxTargets;
        }
    }

    //prefab
    public GameObject target;
    public List<GameObject> targets;

    void Awake() {
        targets = new List<GameObject>();
        _maxTargets = 20;
        _distanceToGen = 10f;

        if (_instance == null)
			_instance = this;
    }
}