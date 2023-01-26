using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed = 1f;
	public float rollSpeed = 2f;
	public float rollTime = 0.5f;

	public Vector2 facing = new Vector2(0, 0);

	private Rigidbody2D playerRigidbody;
	private PlayerInput playerInput;
	private bool rolling = false;
	private IEnumerator rollCoroutine;

	private void Start() {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerInput = GetComponent<PlayerInput>();
		DontDestroyOnLoad(this.gameObject);
	}

	private void FixedUpdate() {
		if (!rolling) {
			Move();
			if (Input.GetKey(KeyCode.Space))
				StartToRoll();
		}
	}

	private void Move() {
		Vector2 moveDirection = CalcMoveDirection();
		Vector2 moveDistance = moveDirection * moveSpeed * Time.fixedDeltaTime;

		Vector2 newPosition = playerRigidbody.position + moveDistance;

		playerRigidbody.MovePosition(newPosition);
	}

	private void StartToRoll() {
		Vector2 rollDirection = CalcMoveDirection();
		Vector2 rollDistance = rollDirection * rollSpeed;

		playerRigidbody.velocity = Vector2.zero;
		playerRigidbody.AddForce(rollDistance, ForceMode2D.Impulse);

		if (rollCoroutine != null)
			StopCoroutine(rollCoroutine);

		rollCoroutine = RollCoroutine(rollTime);
		StartCoroutine(rollCoroutine);
	}

	private IEnumerator RollCoroutine(float seconds) {
		rolling = true;
		yield return new WaitForSeconds(seconds);
		rolling = false;
	}

	private Vector2 CalcMoveDirection() {
		float moveVertical = playerInput.moveVertical;
		float moveHorizontal = playerInput.moveHorizontal;
		Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

		int _xFacing = 0;
		int _yFacing = 0;
		if (moveHorizontal < 0) {
			_xFacing = -1;
		}
		else if (moveHorizontal > 0) {
			_xFacing = 1;
		}
		if (moveVertical < 0) {
			_yFacing = -1;
		}
		else if (moveVertical > 0) {
			_yFacing = 1;
		}

		if(!(_xFacing == 0 && _yFacing == 0)) {
			facing = new Vector2(_xFacing, _yFacing);
		}

		return moveDirection;
	}
}