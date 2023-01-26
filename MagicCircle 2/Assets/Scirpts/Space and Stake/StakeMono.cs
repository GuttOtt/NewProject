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

	public int CurrentStateInt {
		get {
			if (currentState == StakeState.TurnedOn) {
				return 1;
			}
			else if (currentState == StakeState.InCircle) {
				return 2;
			}
			else if (currentState == StakeState.Corrupted) {
				return 3;
			}
			else {
				return 0;
			}
		}
	}

	//각Space 에서 생성
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

	public void InCircle() {
		currentState = StakeState.InCircle;
	}
}

//MonoBehavior가 없는 Stake를 위해 대리자 역할만을 수행해야 한다
//그 외의 기능을 절대 추가하지 말 것
//호출자 역시 Stake에 한정되어야 한다
//MapManager에 하나만 존재
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
