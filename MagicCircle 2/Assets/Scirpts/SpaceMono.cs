using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space {
	private Stake stake;
	private int xIndex;
	private int yIndex;
	private SpaceUI spaceUI;
	private bool isPlayerHere = false;
	private SpaceMono spaceMono;

	public Stake ContainedStake {
		get {return stake; }
	}

	public int XIndex {
		get { return xIndex; }
	}

	public int YIndex {
		get { return yIndex; }
	}

	public bool IsPlayerHere {
		get { return isPlayerHere; }
	}

	//MapManager에서 생성
	public Space(int _xIndex, int _yIndex) {
		//인덱스와 말뚝
		xIndex = _xIndex;
		yIndex = _yIndex;

		stake = new Stake(this);

		//SpaceUI 생성
		spaceMono = MapManager.Instance.spaceMono;
		spaceUI = spaceMono.MakeUI();
		spaceUI.Initialize(xIndex, yIndex, this);
	}

	public void ReplacePlayer() {
		if (isPlayerHere) { 
			isPlayerHere = false;
			MapManager.Instance.presentSpace = null;
		}
		else {
			isPlayerHere = true;
			MapManager.Instance.presentSpace = this;
		}
	}

	public void UIOn() {
		spaceMono.UIOn(spaceUI);
	}

	public void UIOff() {
		spaceMono.UIOff(spaceUI);
	}
}

//MonoBehavior가 없는 Space를 위해 대리자 역할만을 수행해야 한다
//그 외의 기능을 절대 추가하지 말 것
//호출자 역시 Stake에 한정되어야 한다
//MapManager에 하나만 존재
public class SpaceMono : MonoBehaviour {
	public SpaceUI spaceUIPrefab;

	public void UIOn(SpaceUI spaceUI) {
		spaceUI.gameObject.SetActive(true);
	}

	public void UIOff(SpaceUI spaceUI) {
		spaceUI.gameObject.SetActive(false);
	}

	public SpaceUI MakeUI() {
		SpaceUI spaceUI = Instantiate(spaceUIPrefab, MapUIManager.Instance.transform);
		return spaceUI;
	}
}