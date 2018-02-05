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

	private float _scrollingSpeed;
	
	public float scrollingSpeed {
		get {
			return _scrollingSpeed;
		}
	}


	void Awake() {
		_scrollingSpeed = 3f;

		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);
	}
}
