using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager> {
	public float uiMoveSpeed = 0.1f;

	private void Update() {
		//UIMove();
	}

	private void UIMove() {
		float moveVertical = Input.GetAxisRaw("Vertical");
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		Vector3 moveDistance = new Vector3(moveHorizontal, moveVertical, 0);

		transform.position += moveDistance * uiMoveSpeed;
	}
}
