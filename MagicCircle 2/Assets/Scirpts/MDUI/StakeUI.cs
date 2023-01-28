using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//각 Stake에서 컨트롤 할 수 있도록 한다
public class StakeUI : MonoBehaviour, IMDUI {
	private Image image;
	private Stake stake;
	[SerializeField] private Text textPrefab;
	private Text statusText;
	

	private void Awake() {
		image = GetComponent<Image>();
	}

	private void Update() {
		if (Input.GetMouseButtonUp(1))
			RightMouseUp();
	}

    public void DrawInfo() {
		statusText = Instantiate(textPrefab, transform);//Set Parent to Canvas
		statusText.transform.SetParent(transform.parent.parent);
		statusText.text = stake.status.StatusText();
	}

    public void LeftClicked() {

	}

    public void RightMouseUp() {
		Destroy(statusText);
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
		image.color = Color.grey;
	}

	private void TurnOff() {
		image.color = Color.white;
	}

	private void InCircle() {
		image.color = Color.red;
	}

	private void Corrupted() {
		image.color = Color.black;
	}
}