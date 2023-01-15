using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager> {
	public float uiMoveSpeed = 0.1f;
	public int uiMapSize = 9;
	public SpaceUI spaceUIPrefab;

	private SpaceUI[,] uiMap; 

	private void Update() {
	}

	public void Initialize() {
		uiMap = new SpaceUI[uiMapSize, uiMapSize];

		for (int i = 0; i < uiMapSize; i++) {
			for (int j = 0; j < uiMapSize; j++) {
				//SpaceUI ����. StakeUI�� SpaceUI�� Start()���� �ڵ� ������
				SpaceUI ui = Instantiate(spaceUIPrefab, this.transform);
				uiMap[i, j] = ui;
				
				float sprSize = ui.GetComponent<SpriteRenderer>().bounds.size.x;
				ui.transform.localPosition = new Vector2(j, -i) * sprSize;
			}
		}

		Centering();
	}

	public void Centering() {
		int xPresent = MapManager.Instance.presentSpace.XIndex;
		int yPresent = MapManager.Instance.presentSpace.YIndex;
		int xCenter = xPresent;
		int yCenter = yPresent;
		int xMapSize = MapManager.Instance.xMapSize;
		int yMapSize = MapManager.Instance.yMapSize;

		//���� �� üũ
		for (int i = 1; i <= Mathf.Ceil(uiMapSize/2); i++) {
			if (xPresent - i < 0) {
				xCenter++;
			}
		}
		//���� �� üũ
		for (int i = 1; i <= Mathf.Ceil(uiMapSize/2); i++) {
			if (xPresent + i >= xMapSize) {
				xCenter--;
			}
		}
		//�� �� üũ
		for (int i = 1; i <= Mathf.Ceil(uiMapSize/2); i++) {
			if (yPresent - i < 0) {
				yCenter++;
			}
		}
		//�Ʒ� �� üũ
		for (int i = 1; i <= Mathf.Ceil(uiMapSize/2); i++) {
			if (yPresent + i >= yMapSize) {
				yCenter--;
			}
		}

		int xOrigin = xCenter - (int) Mathf.Ceil(uiMapSize / 2);
		int yOrigin = yCenter - (int) Mathf.Ceil(uiMapSize / 2);

		UpdateMapUI(xOrigin, yOrigin);
	}

	//MŰ�� ���� �� GameManager���� ȣ��
	private void UpdateMapUI(int xOrigin, int yOrigin) {
		for (int i = 0; i < uiMapSize; i++) {
			for (int j = 0; j < uiMapSize; j++) {
				Space space = MapManager.Instance.map[yOrigin + i, xOrigin + j];
				uiMap[i, j].UpdateUI(space);
			}
		}
	}
}
