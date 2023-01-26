using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour { 
	public MagicWeapon selectedWeapon;

	private IWeaponEffect selectedEffect;
	private PlayerInput playerInput;
	private PlayerWeaponInventory inventory;

	private void Start() {
		playerInput = GetComponent<PlayerInput>();
		inventory = GetComponent<PlayerWeaponInventory>();
		SelectMagic(0);
	}

	private void Update() {
		if (playerInput.useMagic && selectedEffect != null) {
			selectedEffect.TryToUse();
		}

		if (playerInput.number != -1 && playerInput.number - 1 < inventory.weapons.Count) {
			SelectMagic(playerInput.number - 1);
		}
	}

	private void SelectMagic(int slotNumber) {
		if (selectedWeapon != null)
			selectedWeapon.Deselect();

		selectedWeapon = inventory.weapons[slotNumber];
		selectedWeapon.Select();
		selectedEffect = selectedWeapon.GetComponent<IWeaponEffect>();

		Debug.Log(slotNumber + "Selected");
	}
}