using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake {
	public readonly Space space;
	private StakeMono stakeMono;
	private StakeUI stakeUI;
	
	public enum StakeState {
		TurnedOff,
		TurnedOn,
		InCircle,
		Corrupted
	}
	private StakeState currentState;

	public StakeState CurrentState {
		get { return currentState; }
	}

	//��Space ���� ����
	public Stake(Space _space) {
		space = _space;
		currentState = StakeState.TurnedOff;

		stakeMono = MapManager.Instance.stakeMono;
	}

	public void MakeControl() {
		stakeMono.MakeControl(this);
	}
	
	public void OnControlInteracted() {
		if (currentState == StakeState.TurnedOff) {
			TurnOn();
		}
		else if (currentState == StakeState.TurnedOn) {
			TurnOff();
		}
	}

	private void TurnOn() {
		currentState = StakeState.TurnedOn;
	}

	private void TurnOff() {
		currentState = StakeState.TurnedOff;

	}

	private void InCircle() {

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

	public void MakeControl(Stake stake) {
		StakeControl stakeControl = Instantiate(stakeControllerPrefab);
		stakeControl.Initialize(stake);
	}
}