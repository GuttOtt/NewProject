using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

//�� 4~6ĭ. �÷��̾ �����ϰ� �ִ� �������� �����ش�
//���콺 ���� ����� �� �Ʒ��� Ž���� �� �ִ�
//SpaceUI�� ���� ������ ���� ��

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
		blankParent.transform.localPosition += (Vector3.down + Vector3.right) * 0.05f;
	}
	
	public void DrawUI() {
		foreach (GameObject obj in blankList) {
			Destroy(obj);
		}
		blankList.Clear();

		if (magicCircle != null) {
			Vector3 pos;
			Array2DInt design = magicCircle.data.design;
			int xLength = design.GridSize.x;
			int yLength = design.GridSize.y;
			float blankSize = blankPrefabW.GetComponent<SpriteRenderer>().bounds.size.x;
			

			for (int y = 0; y < yLength; y++) {
				for (int x = 0; x < xLength; x++) {
					pos = new Vector3(x * blankSize, -y * blankSize, 0);
					GameObject newBlank;

					if (design.GetCell(x, y) == 0) {
						newBlank = Instantiate(blankPrefabW, blankParent.transform);

					}
					else {
						newBlank = Instantiate(blankPrefabB, blankParent.transform);
					}
				
					newBlank.transform.localPosition = pos;
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
		Space[,] corSpaces = DesignChecker.CorrespondingSpaces(magicCircle);

		if (corSpaces != null) {
			foreach (Space space in corSpaces) {
				if (space.stake.CurrentStateInt == 1)
					space.stake.InCircle();
			}
			
			MapUIManager.Instance.UpdateUI(); //Stake.InCircle���� �ϱ�?
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