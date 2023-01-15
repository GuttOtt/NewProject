using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
	public float interactDistance = 1f;

	private PlayerInput playerInput;
	private PlayerMove playerMove;
	private LayerMask layerMask;

	private void Start() {
		playerInput = GetComponent<PlayerInput>();
		playerMove = GetComponent<PlayerMove>();
		layerMask = LayerMask.GetMask("Interactable");
	}

	private void Update() {
		if (playerInput.interact) {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, playerMove.facing * interactDistance, interactDistance
								, layerMask);

			if (hit.collider != null) {
				IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
				
				if (interactable != null) {
					interactable.OnInteract();
				}
			}

		}
	}
}