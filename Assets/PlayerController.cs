using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    void Update() {
        if (!isLocalPlayer) {
            return;
        }

        var rot = -Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var move = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, 0, rot);
        transform.Translate(move, 0, 0);
    }

    public override void OnStartLocalPlayer() {
        foreach (Renderer rend in GetComponentsInChildren <Renderer>()) rend.material.color = Color.blue;
    }
}
