using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour  {
    private Rigidbody2D rb;
    private Vector3 startPos;

    
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        //disable gravity
        rb.gravityScale = 0f;
        //disable rotating
        rb.freezeRotation = true;
    }

}