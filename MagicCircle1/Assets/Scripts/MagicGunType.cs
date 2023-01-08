using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGunType : Magic {
	public Projectile projPrefab;

	private void Awake() {
		onUse += Fire;
	}

	private void Fire() {
		Vector3 origin = transform.position;
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		float x = mousePos.x;
		float y = mousePos.y;
		Vector3 direction = new Vector3(mousePos.x, mousePos.y, 0) - origin;

		Projectile proj = Instantiate(projPrefab, transform.position, Quaternion.FromToRotation(Vector3.up, direction));
	}
}
