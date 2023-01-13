using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignUIManager : Singleton<DesignUIManager> {
	public DesignUI designUIPrefab;
	public float uiInterval = 0.25f;
	public float scrollSize = 0.5f;

	private List<DesignUI> designUIList = new List<DesignUI>();
	private List<GameObject> stakeMarkers = new List<GameObject>();
	private List<DesignUI> presentingUI = new List<DesignUI>();
	private List<DesignUI> uiInScrollSize = new List<DesignUI>();

	void Start() {
		Initialize();
		ArrangeDesignUI();
		gameObject.SetActive(false);
	}
	
	void Update() {
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			UIMoveDown();
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			UIMoveUp();
		}
	}

	void Initialize() {
		//Instantiate designUIs
		foreach (CircleDesign design in DesignManager.Instance.ownedDesigns) {
			DesignUI designUI = Instantiate(designUIPrefab, this.transform);
			designUI.SetDesign(design);
			designUIList.Add(designUI);
		}
	}

	void ArrangeDesignUI() {
		
		designUIList[0].transform.localPosition = Vector3.zero;
	
		for (int i = 1; i < designUIList.Count; i++) {
			DesignUI currentUI = designUIList[i];
			DesignUI previousUI = designUIList[i - 1];
			Vector3 origin = previousUI.transform.localPosition;
			float size = previousUI.GetDesign().design.GetLength(0);
			size *= previousUI.blankPrefabW.GetComponent<SpriteRenderer>().bounds.size.y;

			currentUI.transform.localPosition = origin - new Vector3(0, size + uiInterval, 0);
		}
	}

	private void UIMoveUp() {
		gameObject.transform.position += new Vector3(0, scrollSize, 0);
	}

	private void UIMoveDown() {
		gameObject.transform.position -= new Vector3(0, scrollSize, 0);
	}
}