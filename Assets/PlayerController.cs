using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    void FixedUpdate() {
        if (!isLocalPlayer) {
            return;
        }

        var moveX = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * 3.0f;
        var moveY = Input.GetAxis("Vertical") * Time.fixedDeltaTime * 3.0f;

		var rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.MovePosition(new Vector2(rigidBody.position.x + moveX, rigidBody.position.y + moveY));
    }

    public override void OnStartLocalPlayer() {
        foreach (Renderer rend in GetComponentsInChildren <Renderer>()) rend.material.color = Color.blue;
    }
}
