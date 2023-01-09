using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpaceUI : MonoBehaviour, IMDUI {
	public Space space;

	private GameObject info;

	void Awake() {
		MapUIManager.Instance.onUpdate += onUpdate;
		Debug.Log("onUpdate");
	}

	public void DrawUI() {

	}

	public void DrawInfo() {

	}

	public void LeftClicked() {
		//For Debug
	}

	public void RightMouseUp() {
		if (info != null) {
			Destroy(info);
		}
	}

	public void RightMouseDown() {
		DrawInfo();
	}

	private void onUpdate() {
		if (space.stake.state == 0) {
			SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
			spr.color = Color.white;
		}
		else if (space.stake.state == 1) {
			SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
			spr.color = Color.grey;
		}
	}
}
