using System; //For Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager> {
	public MapSpaceUI mapSpaceUIPrefab;
	public GameObject presentSpaceMarker;
	public GameObject presentSpaceMarkerPrefab;

	public MapSpaceUI[,] mapUI;
	public Space[,] map;
	public Action onUpdate;

	private void OnEnable() {
		if (map != null && onUpdate != null)
			onUpdate();
	}

	private void Start() {
		Initialize();
		GameManager.Instance.onLoadNewScene += DrawPresentSpaceMarker;

		gameObject.SetActive(false);
	}

	private void Initialize() {
		map = MapManager.Instance.map;

		int xLength = map.GetLength(1);
		int yLength = map.GetLength(0);

		mapUI = new MapSpaceUI[xLength, yLength];

		for (int i = 0; i < yLength; i++) {
			for (int j = 0; j < xLength; j++) {
				mapUI[i, j] = Instantiate(mapSpaceUIPrefab, this.gameObject.transform);
				mapUI[i, j].space = map[i, j];
			}
		}

		ArrangeUI();
		DrawPresentSpaceMarker();
	}

	private void ArrangeUI() {
		int xLength = map.GetLength(1);
		int yLength = map.GetLength(0);

		float size = mapSpaceUIPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

		for (int i = 0; i < yLength; i++) {
			for (int j = 0; j < xLength; j++) {
				GameObject obj = mapUI[i, j].gameObject;
				obj.transform.localPosition = new Vector3(j * size, -i * size, 0);
			}
		}
	}

	public MapSpaceUI SpaceToSpaceUI(Space space) {
		int xLength = map.GetLength(1);
		int yLength = map.GetLength(0);

		
		for (int i = 0; i < yLength; i++) {
			for (int j = 0; j < xLength; j++) {
				if (space == map[i, j])
					return mapUI[i, j];
			}
		}

		return null;
	}

	private MapSpaceUI GetPresentSpaceUI() {
		int xLength = map.GetLength(1);
		int yLength = map.GetLength(0);

		for (int i = 0; i < yLength; i++) {
			for (int j = 0; j < xLength; j++) {
				if (mapUI[i, j].space == MapManager.Instance.presentSpace)
					return mapUI[i, j];
			}
		}

		return null;
	}

	private void DrawPresentSpaceMarker() {
		if (presentSpaceMarker != null) 
			Destroy(presentSpaceMarker);

		MapSpaceUI presentSpaceUI = GetPresentSpaceUI();
		
		if (presentSpaceUI != null) {
			presentSpaceMarker = Instantiate(presentSpaceMarkerPrefab, presentSpaceUI.gameObject.transform);
		}
	}
}
