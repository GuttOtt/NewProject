using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space {
	public readonly Stake stake;
	private int xIndex;
	private int yIndex;
	private SpaceUI spaceUI;
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

	//MapManager���� ����
	public Space(int _xIndex, int _yIndex) {
		//�ε����� ����
		xIndex = _xIndex;
		yIndex = _yIndex;

		stake = new Stake(this);

		spaceMono = MapManager.Instance.spaceMono;
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
	public void UIOn(SpaceUI spaceUI) {
		spaceUI.gameObject.SetActive(true);
	}

	public void UIOff(SpaceUI spaceUI) {
		spaceUI.gameObject.SetActive(false);
	}
}