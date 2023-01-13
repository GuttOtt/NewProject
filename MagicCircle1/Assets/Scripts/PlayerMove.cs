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
//애니메이션과 바라보고 있는 방향 처리
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

		//방향키를 하나라도 입력하고 있는 상태라면, facing과 애니메이션을 그에 맞게 설정
		if (_xFacing != 0) {
			//음수라면 Flip

			if (_yFacing < 0) {
				//RightDown으로 애니메이션 변경
			}
			else if (yFacing > 0) {
				//RightUp으로 애니메이션 변경
			}
			else {
				//Right로 애니메이션 변경
			}

			xFacing = _xFacing;
			yFacing = _yFacing;
		}
		else {
			if (_yFacing < 0) {
				//MiddleDown으로 애니메이션 변경
			}
			else if (_yFacing > 0) {
				//Idle으로 애니메이션 변경
			}
			else {
				//
			}
		}
*/