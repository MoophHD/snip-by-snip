using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {

	private static Constants _instance;
	public static Constants instance {
        get {
            if (_instance == null) {
				//finds/creates container for all the global stuff 
                GameObject go = GameObject.Find("global");
                if (go == null)
                    go = new GameObject("global");
                go.AddComponent<Constants>();
                
            }

            return _instance;
        }
	}

	private Vector2 _maxCameraBounds;
    public Vector2 maxCameraBounds {
        get {
            return _maxCameraBounds;
        }
    }

    private Vector2 _minCameraBounds;
    public Vector2 minCameraBounds {
        get {
            return _minCameraBounds;
        }
    }

    private float _scrollingSpeed;
	
	public float scrollingSpeed {
		get {
			return _scrollingSpeed;
		}
	}

	void Awake() {
		//per sec
		_scrollingSpeed = 5f;
		_minCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        _maxCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);
	}
}
