using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public string moveVerticalName = "Vertical";
	public string moveHorizontalName = "Horizontal";
	public string useMagicName = "UseMagic";
	public string rollName = "Roll";

	public float moveVertical { get; private set; }
	public float moveHorizontal { get; private set; }
	public bool useMagic { get; private set; }
	public bool roll { get; private set; }
	
	private void Update() {
		if (GameManager.Instance.isGameOver) {
			moveVertical = 0;
			moveHorizontal = 0;
			useMagic = false;
			roll = false;

			return;
		}

		moveVertical = Input.GetAxis(moveVerticalName);
		moveHorizontal = Input.GetAxis(moveHorizontalName);
		useMagic = Input.GetButton(useMagicName);
		roll = Input.GetButton(rollName);
	}
}