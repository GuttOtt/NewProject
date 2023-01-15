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

	//MapManager���� ����
	public Space(int _xIndex, int _yIndex) {
		//�ε����� ����
		xIndex = _xIndex;
		yIndex = _yIndex;

		stake = new Stake(this);

		//SpaceUI ����
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

//MonoBehavior�� ���� Space�� ���� �븮�� ���Ҹ��� �����ؾ� �Ѵ�
//�� ���� ����� ���� �߰����� �� ��
//ȣ���� ���� Stake�� �����Ǿ�� �Ѵ�
//MapManager�� �ϳ��� ����
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