using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)	{
		var hit = collider.gameObject;
		var health = hit.GetComponent<HealthController> ();

		if (health != null) {
			health.TakeDamage (10);
		}

		Destroy(gameObject);
	}
		
}
