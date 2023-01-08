using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager> {
	public MapSpaceUI mapSpaceUIPrefab;

	public MapSpaceUI[,] mapUI;
	public Space[,] map;

	void Start() {
		Initialize();
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
}
