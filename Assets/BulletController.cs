using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter()	{
		Destroy(gameObject);
	}
}
