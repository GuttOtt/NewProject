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

	//각Space 에서 생성
	public Stake(Space _space) {
		space = _space;
		currentState = StakeState.TurnedOff;

		//UI 초기화
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

	public StakeUI MakeUI() {
		StakeUI stakeUI = Instantiate(stakeUIPrefab, MapUIManager.Instance.transform);
		
		return stakeUI;
	}

	public void MakeController(Stake stake) {
		StakeControl stakeControl = Instantiate(stakeControllerPrefab);
		stakeControl.Initialize(stake);
	}
}
