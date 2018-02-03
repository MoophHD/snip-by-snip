using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contains both state and delegate actions, experimenting
//mostly describes player and the board ('cause those are all this game contains, he)
public class GameReducer : MonoBehaviour {

    // in order to get state props
    private static GameReducer _instance;
	public static GameReducer instance {
        get {
            return _instance;
        }
	}

    //create a class for sit side and state
    /*
    private class SitSide {
        private string side1 = "left";
        private string side2 = "right";
        private string _currentSide = "left";

        public SitSide(string startSide) {
            if ( startSide == side1 || startSide == side2 ) {
                _currentSide = startSide;
            }
        }

        public string Side {
            get {
                return _currentSide;
            }
        }
        public void Swap() {
            _currentSide = _currentSide == side1 ? side2 : side1;
        }
        
    }
     */


	public delegate void onJumpDel();
    public static event onJumpDel onJump;
    public static void jump() {onJump();}

    
	public delegate void onSitDel();
    public static event onSitDel onSit;
    public static void sit() {onSit();}

    // {in} ["jump", "sit"]
    private string _playerState;
    public string playerState {
    get {
        return _playerState;
        }
    }

    // ["left", "right"]
    private string _playerSitSide;
    public string playerSitSide {
    get {
        return _playerSitSide;
        }
    }
    
    void Awake() {
        _playerSitSide = Random.value < .5 ? "left" : "right";
        _playerState = "sit";

        if (_instance == null)
			_instance = this;
    }



    private void changeState(string state) {
        _playerState = state;
        
        //@_@
        switch(state) {
            case "jump": {
                break;
            }
            case "sit": {
                _playerSitSide = _playerSitSide == "left" ? "right" : "left";
                break;
            }
        }
    }

    // private void handleSit() {
    //     _playerSitSide = _playerSitSide == "left"
    //     _playerState = state;
    // }

    void OnEnable() {
        onJump += () => { changeState("jump"); };
        onSit += () => { changeState("sit"); };
    }

    void OnDisable() {
        onJump -= () => { changeState("jump"); };
        onSit -= () => { changeState("sit"); };
    }
}
