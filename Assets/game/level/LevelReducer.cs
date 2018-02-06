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

    private float _distanceToGen;
    public float distanceToGen {
    get {
        return _distanceToGen;
        }
    }
    

    void Awake() {
        _distanceToGen = 10f;

        if (_instance == null)
			_instance = this;
    }
}