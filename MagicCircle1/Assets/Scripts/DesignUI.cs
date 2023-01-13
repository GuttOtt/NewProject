using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignUI : MonoBehaviour, IMDUI {
	public GameObject blankPrefabW;
	public GameObject blankPrefabB;
	public GameObject marker;

	private CircleDesign _design;
	private List<GameObject> info = new List<GameObject>();

	protected void Start() {
		DrawUI();
	}

	protected void Update() {
		if (Input.GetMouseButtonUp(1)) {
			RightMouseUp();
		}
	}

	public void SetDesign(CircleDesign design) {
		_design = design;
	}

	public CircleDesign GetDesign() {
		return _design;
	}

	public void DrawUI() {
		Vector3 pos;
		int[,] design = _design.design;
		int xLength = design.GetLength(1);
		int yLength = design.GetLength(0);
		float blankSize = blankPrefabW.GetComponent<SpriteRenderer>().bounds.size.x;

		for (int i = 0; i < yLength; i++) {
			for (int j = 0; j < xLength; j++) {
				pos = new Vector3(j * blankSize, -i * blankSize, 0);
				GameObject newBlank;

				if (design[i, j] == 0) {
					newBlank = Instantiate(blankPrefabW, this.transform);
					newBlank.transform.localPosition += pos;

				}
				else {
					newBlank = Instantiate(blankPrefabB, this.transform);
					newBlank.transform.localPosition += pos;
				}
			}
		}

		BoxCollider2D col = GetComponent<BoxCollider2D>();
		float xOffset = (xLength - 1) / 2 * blankSize;
		float yOffset = -(yLength - 1) / 2 * blankSize;
		col.offset = new Vector2(xOffset, yOffset);
		col.size = new Vector2(xLength * blankSize, yLength * blankSize);
	}

	public void LeftClicked() {

	}

	public void RightMouseUp() {
		if (info != null) {
			foreach (GameObject obj in info)
				Destroy(obj);
		}

	}

	public void RightMouseDown() {
		Debug.Log("RightMouseDown");
		DrawInfo();
	}

	public void DrawInfo() {
		Space[,] corSpaces = DesignChecker.CorrespondingSpaces(_design);
		Debug.Log(corSpaces);

		if (corSpaces != null) {
			Debug.Log("cor");
			int xLength = corSpaces.GetLength(1);
			int yLength = corSpaces.GetLength(0);

			for (int i = 0; i < yLength; i++){
				for (int j = 0; j < xLength; j++) {
					Space space = corSpaces[i, j];

					if (space.stake.state == 1) {
						MapSpaceUI targetUI = MapUIManager.Instance.SpaceToSpaceUI(space);
						Vector3 pos = targetUI.gameObject.transform.position;

						info.Add(Instantiate(marker, pos, Quaternion.identity));
					}
					
				}
			}
		}
	}
}