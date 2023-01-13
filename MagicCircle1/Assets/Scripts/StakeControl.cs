using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeControl : MonoBehaviour, IInteractable {

	public void OnInteract() {
		Stake stake = MapManager.Instance.presentSpace.stake;

		if (stake.state == 0) {
			stake.state = 1;

			gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
		}
	}
}
