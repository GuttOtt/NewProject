using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeControl : MonoBehaviour, IInteractable {
	public Stake stake;

	public void OnInteract() {
		stake.OnControlInteracted();
	}

	public void Initialize(Stake _stake) {
		stake = _stake;
	}
}