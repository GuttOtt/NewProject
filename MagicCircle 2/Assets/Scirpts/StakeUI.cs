using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�� Stake���� ��Ʈ�� �� �� �ֵ��� �Ѵ�
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