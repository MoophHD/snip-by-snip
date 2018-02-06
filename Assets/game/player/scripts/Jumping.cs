using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jumping : MonoBehaviour {
    private Side side;

    private float upForce = 7.5f;
	private float sideForce = 25f;
	private float fallMultiplier = 2.25f;
	private float lowJumpMultiplier = 1.5f;

    private Rigidbody2D rb;

    void Awake() {
        side = PlayerReducer.instance.sitSide;
        rb = GetComponent<Rigidbody2D>();
    }
	
    void Update() {
        if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && Input.GetButton("Jump")) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

        if (Input.GetMouseButtonDown(0) && PlayerReducer.instance.playerState == "sit") {
            // click on ui
            if( EventSystem.current.IsPointerOverGameObject() ){
                return;
            }

            bool isLeftSide = side.side == side.left;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector2 upwardsVelocity = Vector2.up * upForce;
                                    // current == left ? right : left
            Vector2 sideVelocity = (isLeftSide ? Vector2.right : Vector2.left) * sideForce;

            if ( Physics.Raycast (ray,out hit)) {
    
            }

            rb.velocity = upwardsVelocity + sideVelocity;

            PlayerReducer.jump();
        }
    }
}
