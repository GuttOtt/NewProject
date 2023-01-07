using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignUIManager : Singleton<DesignUIManager> {
	public DesignUI designUIPrefab;
	public GameObject stakeMarkerPrefab;

	private List<DesignUI> designUIList = new List<DesignUI>();
	private List<GameObject> stakeMarkers = new List<GameObject>();

	void Start() {
		Initialize();
		ArrangeDesignUI();
	}
	

	void Initialize() {
		foreach (CircleDesign design in DesignManager.Instance.ownedDesigns) {
			DesignUI designUI = Instantiate(designUIPrefab, transform.position, Quaternion.identity);
			designUI.SetDesign(design);
			designUIList.Add(designUI);
		}
	}

	void ArrangeDesignUI() {
		for (int i = 0; i < designUIList.Count; i++) {
			DesignUI currentUI = designUIList[i];
			float size = currentUI.GetDesign().design.GetLength(0);
			size *= designUIList[i].blankPrefabW.GetComponent<SpriteRenderer>().bounds.size.y;

			currentUI.transform.position += Vector3.down * size * i;
		}
	}
}