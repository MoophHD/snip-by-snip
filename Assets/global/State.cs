using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
	private static State _instance;
	public static State instance {
        get {
            if (_instance == null) {
				//finds/creates container for all the global stuff 
                GameObject go = GameObject.Find("global");
                if (go == null)
                    go = new GameObject("global");
                go.AddComponent<State>();
                
            }

            return _instance;
        }
	}

	void Awake() {
		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);
	}
}
