using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake {
	private Space space;
	private StakeMono stakeMono;
	private StakeUI stakeUI;
	private enum StakeState {
		TurnedOff,
		TurnedOn,
		InCircle,
		Corrupted
	}
	private StakeState currentState;

	//��Space ���� ����
	public Stake(Space _space) {
		space = _space;
		currentState = StakeState.TurnedOff;

		//UI �ʱ�ȭ
		stakeMono = MapManager.Instance.stakeMono;
		stakeUI = stakeMono.MakeUI();
	}

	public void OnControlInteracted() {
		if (currentState == StakeState.TurnedOff) {
			TurnOn();
		}
		else if (currentState == StakeState.TurnedOn) {
			TurnOff();
		}
	}
	
	public void TurnOn() {
		currentState = StakeState.TurnedOn;
		stakeUI.TurnOn();
	}

	public void TurnOff() {
		currentState = StakeState.TurnedOff;
		stakeUI.TurnOff();
	}

	public void InCircle() {
		currentState = StakeState.InCircle;

		stakeUI.InCircle();
	}

	public void MakeController() {
		stakeMono.MakeController(this);
	}
}

//MonoBehavior�� ���� Stake�� ���� �븮�� ���Ҹ��� �����ؾ� �Ѵ�
//�� ���� ����� ���� �߰����� �� ��
//ȣ���� ���� Stake�� �����Ǿ�� �Ѵ�
//MapManager�� �ϳ��� ����
public class StakeMono : MonoBehaviour {
	public StakeUI stakeUIPrefab;
	public StakeControl stakeControllerPrefab;

	public void UIOn(StakeUI stakeUI) {
		stakeUI.gameObject.SetActive(true);
	}

	public void UIOff(StakeUI stakeUI) {
		stakeUI.gameObject.SetActive(false);
	}

	public StakeUI MakeUI() {
		StakeUI stakeUI = Instantiate(stakeUIPrefab, MapUIManager.Instance.transform);
		
		return stakeUI;
	}

	public void MakeController(Stake stake) {
		StakeControl stakeControl = Instantiate(stakeControllerPrefab);
		stakeControl.Initialize(stake);
	}
}
