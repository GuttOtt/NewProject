using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//각 Stake에서 컨트롤 할 수 있도록 한다
public class StakeUI : MonoBehaviour, IMDUI {
	private SpriteRenderer sprRenderer;
	private Stake stake;

	private void Awake() {
		sprRenderer = GetComponent<SpriteRenderer>();
	}

    public void DrawInfo() {

	}

    public void LeftClicked() {

	}

    public void RightMouseUp() {

	}

    public void RightMouseDown() {

	}

	public void UpdateUI(Stake _stake) {
		stake = _stake;

		if (stake.CurrentState == Stake.StakeState.TurnedOn) {
			TurnOn();
		}
		else if (stake.CurrentState == Stake.StakeState.TurnedOff) {
			TurnOff();
		}
		else if (stake.CurrentState == Stake.StakeState.InCircle) {
			InCircle();
		}
		else if (stake.CurrentState == Stake.StakeState.Corrupted){
			Corrupted();
		}
	}

	private void TurnOn() {
		sprRenderer.color = Color.grey;
	}

	private void TurnOff() {
		sprRenderer.color = Color.white;
	}

	private void InCircle() {
		sprRenderer.color = Color.red;
	}

	private void Corrupted() {
		sprRenderer.color = Color.black;
	}
}