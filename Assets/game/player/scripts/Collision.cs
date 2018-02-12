using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collision : MonoBehaviour  {
    // debug
    // bool firstSitFlag = true;
    // Vector3 coll1;
    
    private Side side;
    void Awake() {
        side = PlayerReducer.instance.sitSide;
    }
    void OnCollisionEnter2D(Collision2D coll) {
        string tag = coll.gameObject.tag;
        if (tag == "wall") {
            //is on the right wall while current state is on left etc.
            if ((coll.gameObject.name == "wall_l" && side.side == side.right) ||
                (coll.gameObject.name == "wall_r" && side.side == side.left)
            ) {
                PlayerReducer.sit();

                // ~1.5f y height
                // if (firstSitFlag) {
                //     firstSitFlag = false;
                //     return;
                // }
                // if (coll1 == null) {
                //     coll1 = GetComponent<Transform>().position;
                // } else {
                //     print( GetComponent<Transform>().position.y - coll1.y );
                // }
            }
        } else if (tag == "topPad" || tag == "bottomPad") {
            State.newGame();
        }
    }
}
