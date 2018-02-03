using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    private float upForce = 7.5f;
	private float sideForce = 15f;
	private float fallMultiplier = 2.25f;
	private float lowJumpMultiplier = 1.5f;

    private Rigidbody2D rb;
    private Transform tr;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }
	
    void Update() {
        if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && Input.GetButton("Jump")) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

        if (Input.GetMouseButtonDown(0) && GameReducer.instance.playerState == "sit") {
            bool isLeftSide = GameReducer.instance.playerSitSide == "left";

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector2 upwardsVelocity = Vector2.up * upForce;
                                    // current == left ? right : left
            Vector2 sideVelocity = (isLeftSide ? Vector2.right : Vector2.left) * sideForce;

            if ( Physics.Raycast (ray,out hit,100.0f)) {
                //detect click on ui
            }
            rb.velocity = upwardsVelocity + sideVelocity;

            GameReducer.jump();
        }
    }
}
