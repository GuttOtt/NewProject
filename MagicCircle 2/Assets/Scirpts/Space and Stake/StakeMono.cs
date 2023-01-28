using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status {
	public Status(float power, float speed, float size) {
		this.power = power;
		this.speed = speed;
		this.size = size;
	}

	public Status() {
		Randomize();
	}

	private float power;
	private float speed;
	private float size;

	public void Randomize() {
		power = Random.Range(0, 5);
		speed = Random.Range(0, 5);
		size = Random.Range(0, 5);
	}

	public Status Copy() {
		return new Status(power, speed, size);
	}

	public string StatusText() {
		string statusText = "Power: " + power + "\n" + "Speed: " + speed + "\n" + "Size: " + size;
		return statusText;
	}

	public void Plus(Status other) {
		power += other.power;
		speed += other.speed;
		size += other.size;
	}
}

public class Stake {
	public readonly Space space;
	private StakeMono stakeMono;
	private StakeUI stakeUI;
	
	//StakeStatus
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

	//Status
	private Status _status = new Status();
	public Status status { get => _status; }

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

	public void InCircle() {
		currentState = StakeState.InCircle;
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
