using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour  {
    private Transform tr;
    private Rigidbody2D rb;
    private Vector3 startPos;
    public float playerDownForce;
    void Awake() {
        playerDownForce = 5f;

        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        //disable native gravity
        rb.gravityScale = 0f;
    
        rb.AddForce(Vector3.down * playerDownForce);
        //disable rotating
        rb.freezeRotation = true;

        startPos = tr.position;
    }

    public void resetPos() {
        tr.position = startPos;
    }

}