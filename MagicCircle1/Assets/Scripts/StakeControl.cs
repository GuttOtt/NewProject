using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeControl : MonoBehaviour, IInteractable {
	public Stake stake;

	public void OnInteract() {
			Debug.Log("stake");
		if (stake.state == 0) {
			stake.state = 1;
		}
	}

	public void SetStake(Stake _stake) {
		stake = _stake;
	}
}
