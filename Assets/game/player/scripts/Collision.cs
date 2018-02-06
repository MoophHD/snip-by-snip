using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collision : MonoBehaviour  {
    private Side side;
    void Awake() {
        side = PlayerReducer.instance.sitSide;
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "wall") {
            //is on the right wall while current state is on left etc.
            if ((coll.gameObject.name == "wall_l" && side.side == side.right) ||
                (coll.gameObject.name == "wall_r" && side.side == side.left)
            ) {
                PlayerReducer.sit();
            }
        }
    }
}