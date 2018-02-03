using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour  {
    public bool isLeftSide;

    public float marginX = 2.6f;
    private Transform tr;
    private Rigidbody2D rb;

    
    void Awake() {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        
        //disable gravity
        rb.gravityScale = 0f;
        //disable rotating
        rb.freezeRotation = true;

        isLeftSide = Random.value < .5 ? true : false;

        setToSide();
    }

    void setToSide() {
        tr.position = new Vector3((isLeftSide ? -marginX : marginX), 0f, 0f);
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "wall") {
            //is on the right wall while current state is on left etc.
            if ((coll.gameObject.name == "wall_l" && GameReducer.instance.playerSitSide == "right") ||
                (coll.gameObject.name == "wall_r" && GameReducer.instance.playerSitSide == "left")
            ) {
                GameReducer.sit();
            }
        }
    }
}