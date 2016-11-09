using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)	{
		var hit = collision.gameObject;
		var health = hit.GetComponent<HealthController> ();

		if (health != null) {
			health.TakeDamage (10);
		}

		Destroy(gameObject);
	}
		
}
