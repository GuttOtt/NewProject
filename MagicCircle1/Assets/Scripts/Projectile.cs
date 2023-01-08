using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float damage;
	public float moveSpeed;

	private void Update() {
		Move();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		IDamageable target = (other.gameObject.GetComponent<IDamageable>());

		if (target != null){
			Damage(target);
		}
	}

	private void Move() {
		transform.position += transform.up * moveSpeed;
	}

	private void Damage(IDamageable target) {
		target.OnDamage();
	}
}
