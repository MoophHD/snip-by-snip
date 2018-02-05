using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contains both state and delegate actions, experimenting
//mostly describes player and the board ('cause those are all this game contains, he)
public class PlayerReducer : MonoBehaviour {

    // in order to get state props
    private static PlayerReducer _instance;
	public static PlayerReducer instance {
        get {
            return _instance;
        }
	}

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
    private Side _sitSide;
    public Side sitSide {
    get {
        return _sitSide;
        }
    }
    
    void Awake() {
        _sitSide = new Side(Random.value < .5 ? "left" : "right");
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
                _sitSide.Swap();
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
