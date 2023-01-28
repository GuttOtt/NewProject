using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

//총 4~6칸. 플레이어가 소유하고 있는 마법진을 보여준다
//마우스 휠을 사용해 위 아래로 탐색할 수 있다
//SpaceUI와 같은 구조로 만들 것

public class MagicCircleUI : MonoBehaviour, IMDUI {
	public GameObject blankPrefabW;
	public GameObject blankPrefabB;
	public GameObject marker;

	public MagicCircle magicCircle;
	private List<GameObject> infoList = new List<GameObject>();
	private List<GameObject> blankList = new List<GameObject>();
	private GameObject blankParent;

	private void Start() {
		blankParent = new GameObject("BlankParent");
		blankParent.transform.SetParent(this.transform);
		blankParent.transform.localPosition = Vector3.zero;
		blankParent.transform.localPosition += (Vector3.down + Vector3.right) * 3f;
	}
	
	public void DrawUI() {
		foreach (GameObject obj in blankList) {
			Destroy(obj);
		}
		blankList.Clear();

		if (magicCircle != null) {
			Array2DInt design = magicCircle.data.design;
			int xLength = design.GridSize.x;
			int yLength = design.GridSize.y;
			

			for (int y = 0; y < yLength; y++) {
				for (int x = 0; x < xLength; x++) {
					GameObject newBlank;

					if (design.GetCell(x, y) == 0) {
						newBlank = Instantiate(blankPrefabW, blankParent.transform);

					}
					else {
						newBlank = Instantiate(blankPrefabB, blankParent.transform);
					}
					
					RectTransform rect = newBlank.GetComponent<RectTransform>();
					float blankSize = rect.sizeDelta.x;
					rect.anchoredPosition += new Vector2(x * blankSize, -y * blankSize);
					blankList.Add(newBlank);

					blankParent.transform.localScale = new Vector3(1f / yLength, 1f / yLength, 0);
					blankParent.transform.localScale *= 0.97f;
				}
			}
		}
	}

	public void DrawInfo() {

	}

	public void LeftClicked() {
		Space[,] corSpaces = magicCircle == null ? null : DesignChecker.CorrespondingSpaces(magicCircle);

		if (corSpaces != null) {
			foreach (Space space in corSpaces) {
				if (space.stake.CurrentStateInt == 1)
					space.stake.InCircle();
			}
			
			MapUIManager.Instance.UpdateUI(); //Stake.InCircle에서 하기?
			magicCircle.Complete();
		}
	}

	public void RightMouseDown() {

	}

	public void RightMouseUp() {

	}

	public void UpdateUI(MagicCircle _magicCircle) {
		magicCircle = _magicCircle;

		DrawUI();
	}
}