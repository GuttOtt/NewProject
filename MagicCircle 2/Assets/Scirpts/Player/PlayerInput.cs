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
	public int number { get; private set; }

	private void Start() {
		number = -1;
	}
	
	private KeyCode[] keyCodeNumbers = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Alpha4,
		KeyCode.Alpha5,
		KeyCode.Alpha6,
		KeyCode.Alpha7,
		KeyCode.Alpha8,
		KeyCode.Alpha9
	};

	private void Update() {
		if (GameManager.Instance.isGameOver || GameManager.Instance.isUIOn) {
			moveVertical = 0;
			moveHorizontal = 0;
			useMagic = false;
			roll = false;
			number = -1;

			return;
		}

		moveVertical = Input.GetAxisRaw(moveVerticalName);
		moveHorizontal = Input.GetAxisRaw(moveHorizontalName);
		useMagic = Input.GetButton(useMagicName);
		interact = Input.GetButtonDown(interactName);
		roll = Input.GetButtonDown(rollName);
		
		number = -1;
		for (int i = 0; i < keyCodeNumbers.Length; i++) {
			if (Input.GetKeyDown(keyCodeNumbers[i])) {
				number = i + 1;
			}
		}
	}
}