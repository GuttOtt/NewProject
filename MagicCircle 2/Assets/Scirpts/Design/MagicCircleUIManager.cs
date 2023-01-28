using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleUIManager : Singleton<MagicCircleUIManager> {
	public MagicCircleUI magicCircleUIPrefab;
	public int xUISize = 2;
	public int yUISize = 3;
	public MagicCircleUI[,] magicCircleUI;

	[SerializeField] private Canvas canvasPrefab;
	private Canvas canvas;
	private int scopeOrigin = 0;

	protected void Start() {
		Initialize();
	}

	private void Initialize() {
		magicCircleUI = new MagicCircleUI[yUISize, xUISize];

		canvas = Instantiate(canvasPrefab, this.transform);

		for (int y = 0; y < yUISize; y++) {
			for (int x = 0; x < xUISize; x++) {
				magicCircleUI[y, x] = Instantiate(magicCircleUIPrefab, canvas.transform);

				RectTransform uiRect = magicCircleUI[y,x].GetComponent<RectTransform>();
				float uiSpriteSize = uiRect.sizeDelta.x;
				uiRect.anchoredPosition += new Vector2(x * uiSpriteSize, -y * uiSpriteSize);
			}
		}

		UpdateUI();
	}

	public void UpdateUI() {
		List<MagicCircle> inventory = MagicCircleManager.Instance.magicCircleInventory;

		for (int y = 0; y < yUISize; y++) {
			for (int x = 0; x < xUISize; x++) {
				int presentIndex = (scopeOrigin + y) * 2 + x;
				MagicCircle magicCircle = null;

				if (presentIndex < inventory.Count) {
					magicCircle = inventory[presentIndex];
				}
				
				magicCircleUI[y, x].UpdateUI(magicCircle);
				
			}
		}
	}
}
