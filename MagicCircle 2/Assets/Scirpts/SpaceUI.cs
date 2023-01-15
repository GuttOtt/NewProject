using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각 Space에서 컨트롤 할 수 있도록 한다

public class SpaceUI : MonoBehaviour, IMDUI {
	public GameObject playerMarkerPrefab;

	private int xIndex, yIndex;
	private Space space;
	private GameObject playerMarker;

	public void DrawInfo() {

	}

	public void LeftClicked() {

	}

	public void RightMouseUp() {

	}

	public void RightMouseDown() {
		DrawInfo();
	}

	//MapManager를 통해 각 Space에서 호출
	public void UpdateUI() {
		if (space.IsPlayerHere) {
			DrawPlayerMarker();
		}
		else {
			Destroy(playerMarker);
		}
	}

	private void DrawPlayerMarker() {
		if (playerMarker != null) {
			Destroy(playerMarker);
		}

		playerMarker = Instantiate(playerMarkerPrefab, this.transform);
	}

	public void Initialize(int x, int y, Space _space) {
		xIndex = x;
		yIndex = y;
		space = _space;

		Arrange();
	}

	public void Arrange() {
		float uiSize = GetComponent<SpriteRenderer>().bounds.size.x;
		transform.localPosition = new Vector2(xIndex * uiSize, -yIndex * uiSize);
	}
}