using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;


  void FixedUpdate() {
    if (!isLocalPlayer) {
        return;
    }



		Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, Camera.main.transform.position.z); 

    var moveX = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * 3.0f;
    var moveY = Input.GetAxis("Vertical") * Time.fixedDeltaTime * 3.0f;

		var rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.MovePosition(new Vector2(rigidBody.position.x + moveX, rigidBody.position.y + moveY));

		// SHOOT SOME BUNNIES
		if (Input.GetMouseButtonDown(0))
		{
			CmdFire();
		}
  }

  public override void OnStartLocalPlayer() {
    foreach (Renderer rend in GetComponentsInChildren <Renderer>()) rend.material.color = Color.blue;
  }

	[Command]
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 6;

		// Spawn the bullet on the clients
		NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
}
