using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWeaponizing: MonoBehaviour, IMagic {
	public MagicWeapon weaponPrefab;

	private MagicWeapon Weaponize(Status status) {
		MagicWeapon weapon = Instantiate(weaponPrefab);
		weapon.Decorate(status);
		return weapon;
	}

	public void Activate(Status status) {
		PlayerWeaponInventory playerInventory = FindObjectOfType<PlayerWeaponInventory>();
		playerInventory.AddWeapon(Weaponize(status));
	}

}