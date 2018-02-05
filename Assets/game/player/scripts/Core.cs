using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour  {
    private Side side;
    public bool isLeftSide;

    public float marginX = 2.6f;
    private Transform tr;
    private Rigidbody2D rb;

    
    void Awake() {
        side = PlayerReducer.instance.sitSide;
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        
        //disable gravity
        rb.gravityScale = 0f;
        //disable rotating
        rb.freezeRotation = true;
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