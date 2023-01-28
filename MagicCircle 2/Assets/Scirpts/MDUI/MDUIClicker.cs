using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDUIClicker : MonoBehaviour {
	void Update() {
		if (Input.GetMouseButtonDown(0))
			LeftClick();
		else if (Input.GetMouseButtonDown(1))
			RightDown();
	}

	private void LeftClick() {
		IMDUI ui = UIOnMouse();

		if (ui != null) {
			ui.LeftClicked();
		}
	}

	private void RightDown() {
		IMDUI ui = UIOnMouse();

		if (ui != null) {
			ui.RightMouseDown();
		}
	}

	private IMDUI UIOnMouse() {
		Vector3 mousePos = Input.mousePosition;
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

		if (hit.collider != null) {
			return hit.collider.gameObject.GetComponent<IMDUI>();
		}
		else
			return null;
	}
}