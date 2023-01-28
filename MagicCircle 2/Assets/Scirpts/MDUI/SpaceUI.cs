using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceUI : MonoBehaviour, IMDUI {
	public GameObject playerMarkerPrefab;
	public StakeUI stakeUIPrefab;

	private Space space;
	private GameObject playerMarker;
	private StakeUI stakeUI;

	private void Awake() {
		stakeUI = Instantiate(stakeUIPrefab, transform);
	}

	public void DrawInfo() {

	}

	public void LeftClicked() {

	}

	public void RightMouseUp() {

	}

	public void RightMouseDown() {
		DrawInfo();
		stakeUI.DrawInfo();
		Debug.Log("SpaceUiRightDown");
	}

	//MapUIManager에서 호출
	public void UpdateUI(Space _space) {
		space = _space;

		if (MapManager.Instance.presentSpace == space) {
			DrawPlayerMarker();
		}
		else {
			Destroy(playerMarker);
		}

		stakeUI.UpdateUI(space.ContainedStake);
	}

	private void DrawPlayerMarker() {
		if (playerMarker != null) {
			Destroy(playerMarker);
		}

		playerMarker = Instantiate(playerMarkerPrefab, this.transform);
	}

	public void Initialize(int x, int y, Space _space) {
		space = _space;
	}
}