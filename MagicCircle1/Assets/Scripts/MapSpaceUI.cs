using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpaceUI : MonoBehaviour, IMDUI {
	public Space space;

	private GameObject info;

	public void DrawUI() {

	}

	public void DrawInfo() {

	}

	public void LeftClicked() {
		//For Debug
		if (space.stake.state == 0) {
			SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
			spr.color = Color.grey;

			space.stake.state = 1;
		}
		else if (space.stake.state == 1) {
			SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
			spr.color = Color.white;

			space.stake.state = 0;
		}
	}

	public void RightMouseUp() {
		if (info != null) {
			Destroy(info);
		}
	}

	public void RightMouseDown() {
		DrawInfo();
	}
}
