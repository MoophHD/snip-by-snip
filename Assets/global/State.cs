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

	private bool _isGameFrozen;

	public bool isGameFrozen {
		get {
			return _isGameFrozen;
		}
	}

	public delegate void unfreezeDel();
    public static event unfreezeDel onUnfreeze;
    public static void unfreeze() {onUnfreeze();}

	public delegate void freezeDel();
    public static event freezeDel onFreeze;
    public static void freeze() {onFreeze();}

	public delegate void _onNewGame();
    public static event _onNewGame onNewGame;
    public static void newGame() {onNewGame();}

	void OnEnable() {
 		onFreeze += () => { Time.timeScale = 0; _isGameFrozen = true; };
        onUnfreeze += () => { Time.timeScale = 1; _isGameFrozen = false; };

        onNewGame += () => { freeze(); };
    }

    void OnDisable() {
 		onFreeze -= () => { Time.timeScale = 0; _isGameFrozen = true; };
        onUnfreeze -= () => { Time.timeScale = 1; _isGameFrozen = false; };

        onNewGame -= () => { freeze(); };
    }

	void Awake() {
		_scrollingSpeed = 7f;
		_isGameFrozen = true;

		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);
	}

	void Start() {
		newGame();
	}
}
