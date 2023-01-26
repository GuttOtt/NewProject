using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager> {
	public float uiMoveSpeed = 0.1f;
	public int uiMapSize = 9;
	public SpaceUI spaceUIPrefab;

	private SpaceUI[,] uiMap; 
	private int _xScopeOrigin;
	private int _yScopeOrigin;

	private int xScopeOrigin {
		get {
			return _xScopeOrigin;
		}

		set {
			_xScopeOrigin = value;

			//Adjusting
			int xScopeEnd = _xScopeOrigin + uiMapSize - 1; //End index
			int xMapEnd = MapManager.Instance.xMapSize - 1; //End index

			if (_xScopeOrigin < 0) {
				_xScopeOrigin = 0;
			}
			else if (xMapEnd < xScopeEnd) {
				int gap = xScopeEnd - xMapEnd;
				_xScopeOrigin -= gap;
			}
		}
	}

	private int yScopeOrigin {
		get {
			return _yScopeOrigin;
		}

		set {
			_yScopeOrigin = value;

			int yScopeEnd = _yScopeOrigin + uiMapSize - 1; //End index
			int yMapEnd = MapManager.Instance.yMapSize - 1; //End index

			if (_yScopeOrigin < 0) {
				_yScopeOrigin = 0;
			}
			else if (yMapEnd < yScopeEnd) {
				int gap = yScopeEnd - yMapEnd;
				_yScopeOrigin -= gap;
			}
		}
	}

	private void Update() {
		MapUIInput();
	}

	public void Initialize() {
		uiMap = new SpaceUI[uiMapSize, uiMapSize];

		for (int i = 0; i < uiMapSize; i++) {
			for (int j = 0; j < uiMapSize; j++) {
				//SpaceUI 생성. StakeUI는 SpaceUI의 Start()에서 자동 생성됨
				SpaceUI ui = Instantiate(spaceUIPrefab, this.transform);
				uiMap[i, j] = ui;
				
				float sprSize = ui.GetComponent<SpriteRenderer>().bounds.size.x;
				ui.transform.localPosition = new Vector2(j, -i) * sprSize;
			}
		}

		Centering();
	}
	
	//M키를 누를 때 GameManager에서 호출
	public void Centering() {
		int xPresent = MapManager.Instance.presentSpace.XIndex;
		int yPresent = MapManager.Instance.presentSpace.YIndex;
		int xNewOrigin = xPresent - (int) Mathf.Ceil(uiMapSize / 2);
		int yNewOrigin = yPresent - (int) Mathf.Ceil(uiMapSize / 2);

		//Property로 인해 자동 보정 됨
		xScopeOrigin = xNewOrigin;
		yScopeOrigin = yNewOrigin;

		UpdateUI();
	}

	public void UpdateUI() {
		for (int i = 0; i < uiMapSize; i++) {
			for (int j = 0; j < uiMapSize; j++) {
				Space space = MapManager.Instance.map[yScopeOrigin + i, xScopeOrigin + j];
				uiMap[i, j].UpdateUI(space);
			}
		}
	}

	private void MapUIInput() {
		if (Input.GetKeyDown(KeyCode.W)) {
			TranslateScope(0, -1);
		}
		else if (Input.GetKeyDown(KeyCode.A)) {
			TranslateScope(-1, 0);
		}
		else if (Input.GetKeyDown(KeyCode.S)) {
			TranslateScope(0, 1);
		}
		else if (Input.GetKeyDown(KeyCode.D)) {
			TranslateScope(1, 0);
		}
	}

	private void TranslateScope(int x, int y) {
		xScopeOrigin = xScopeOrigin + x;
		yScopeOrigin = yScopeOrigin + y;

		UpdateUI();
	}
}