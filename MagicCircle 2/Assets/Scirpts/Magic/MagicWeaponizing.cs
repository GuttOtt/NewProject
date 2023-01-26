using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWeaponizing: MonoBehaviour, IMagic {
	public MagicWeapon weapon;	
	public MagicData data;

	public void Activate() {
		PlayerWeaponInventory playerInventory = FindObjectOfType<PlayerWeaponInventory>();

		playerInventory.AddWeapon(weapon);		
	}
}