using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public string moveVerticalName = "Vertical";
	public string moveHorizontalName = "Horizontal";
	public string useMagicName = "UseMagic";
	public string rollName = "Roll";
	public string interactName = "Interact";

	public float moveVertical { get; private set; }
	public float moveHorizontal { get; private set; }
	public bool useMagic { get; private set; }
	public bool roll { get; private set; }
	public bool interact { get; private set; }
	
	private void Update() {
		if (GameManager.Instance.isGameOver) {
			moveVertical = 0;
			moveHorizontal = 0;
			useMagic = false;
			roll = false;

			return;
		}

		moveVertical = Input.GetAxisRaw(moveVerticalName);
		moveHorizontal = Input.GetAxisRaw(moveHorizontalName);
		useMagic = Input.GetButton(useMagicName);
		interact = Input.GetButtonDown(interactName);
		roll = Input.GetButtonDown(rollName);
	}

	private void FixedUpdate() {
	}
}