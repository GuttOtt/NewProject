using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//각 Stake에서 컨트롤 할 수 있도록 한다
public class StakeUI : MonoBehaviour, IMDUI {
	private SpriteRenderer sprRenderer;

	private void Start() {
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


	public void TurnOn() {
		sprRenderer.color = Color.white;
	}

	public void TurnOff() {
		sprRenderer.color = Color.grey;
	}

	public void InCircle() {
		sprRenderer.color = Color.red;

	}
}