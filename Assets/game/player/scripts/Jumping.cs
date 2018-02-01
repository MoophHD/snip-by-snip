using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {
    private Rigidbody2D rb;
    private Transform tr;
	
	void OnEnable()
    {
		Signals.onJump += jump;
    }
    
    void OnDisable()
    {
		Signals.onJump += jump;
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    void jump() {
        rb.AddForce(Vector2.up * 2.5f);
    }
}
