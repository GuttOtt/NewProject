using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseMagic : MonoBehaviour { 
	public Magic chosenMagic; //현재 들고 있는 마법

	private PlayerInput playerInput;

	private void Start() {
		playerInput = GetComponent<PlayerInput>();
		SelectMagic(0);
	}

	private void Update() {
		if (playerInput.useMagic) {
			chosenMagic.TryToUse();
		}
	}

	private void SelectMagic(int slotNumber) {
		if (chosenMagic != null)
			Destroy(chosenMagic);

		Magic selectedMagic = GameManager.Instance.ownedMagic[slotNumber];
		chosenMagic = Instantiate(selectedMagic, this.transform);

	}
}
