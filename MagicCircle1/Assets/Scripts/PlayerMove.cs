using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed = 0.5f;

	private Rigidbody2D playerRigidbody;
	private PlayerInput playerInput;

	private void Start() {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerInput = GetComponent<PlayerInput>();
	}

	private void FixedUpdate() {
		Move();
	}

	private void Move() {
		float moveVertical = playerInput.moveVertical * moveSpeed;
		float moveHorizontal = playerInput.moveHorizontal * moveSpeed;
		Vector2 moveDistance = new Vector3(moveHorizontal, moveVertical) * Time.deltaTime;

		playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
	}
}
