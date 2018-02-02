using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour  {
    public bool isLeftSide;

    public float marginX = 2.6f;
    private Transform tr;
    private Rigidbody2D rb;

    
	void OnEnable()
    {
		Signals.onNewGame += swapSide;
    }
    
    void OnDisable()
    {
		Signals.onNewGame += swapSide;
    }

    void Awake() {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        
        //disable gravity
        rb.gravityScale = 0f;
        //disable rotating
        rb.freezeRotation = true;

        isLeftSide = Random.value < .5 ? true : false;
        resetSelf();
    }

    void swapSide() {
        isLeftSide = !isLeftSide;
        resetSelf();
    }

    void resetSelf() {
        tr.position = new Vector3((isLeftSide ? -marginX : marginX), 0f, 0f);
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "wall") {
            // swapSide();
        }
    }
}