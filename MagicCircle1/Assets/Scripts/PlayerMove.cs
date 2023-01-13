using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed = 0.5f;
	public float rollSpeed = 1f;
	public float rollTime = 0.5f;

	public Vector2 facing = new Vector2(0, 0);

	private Rigidbody2D playerRigidbody;
	private PlayerInput playerInput;
	private bool rolling = false;
	private IEnumerator rollCoroutine;

	private void Start() {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerInput = GetComponent<PlayerInput>();
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
		Debug.Log("Rolling");
		yield return new WaitForSeconds(seconds);
		rolling = false;
		Debug.Log("End Rolling");
	}

	private Vector2 CalcMoveDirection() {
		float moveVertical = playerInput.moveVertical;
		float moveHorizontal = playerInput.moveHorizontal;
		Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

		return moveDirection;
	}
}


/*
//�ִϸ��̼ǰ� �ٶ󺸰� �ִ� ���� ó��
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

		//����Ű�� �ϳ��� �Է��ϰ� �ִ� ���¶��, facing�� �ִϸ��̼��� �׿� �°� ����
		if (_xFacing != 0) {
			//������� Flip

			if (_yFacing < 0) {
				//RightDown���� �ִϸ��̼� ����
			}
			else if (yFacing > 0) {
				//RightUp���� �ִϸ��̼� ����
			}
			else {
				//Right�� �ִϸ��̼� ����
			}

			xFacing = _xFacing;
			yFacing = _yFacing;
		}
		else {
			if (_yFacing < 0) {
				//MiddleDown���� �ִϸ��̼� ����
			}
			else if (_yFacing > 0) {
				//Idle���� �ִϸ��̼� ����
			}
			else {
				//
			}
		}
*/