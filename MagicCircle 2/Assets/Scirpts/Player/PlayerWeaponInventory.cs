using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponInventory: MonoBehaviour {
	public MagicWeapon basicWeaponPrefab;
	public List<MagicWeapon> weapons = new List<MagicWeapon>();

	[SerializeField] WeaponUI weaponUIPrefab;
	[SerializeField] private Canvas canvasPrefab;
	[SerializeField] private List<WeaponUI> weaponUI = new List<WeaponUI>();
	[SerializeField] private int numberOfSlot = 5;
	private Canvas weaponUICanvas;

	public void Awake() {
		InitWeaponUI();
		AddWeapon(basicWeaponPrefab);
	}

	public void AddWeapon(MagicWeapon weaponPrefab) {
		MagicWeapon newWeapon = Instantiate(weaponPrefab, this.transform);
		weapons.Add(newWeapon);

		UIAssign(weapons.Count - 1, newWeapon);
	}

	private void UIAssign(int slotNumber, MagicWeapon weapon) {
		weaponUI[slotNumber].AssignWeapon(weapon);
		weapon.AssignUI(weaponUI[slotNumber]);
	}

	private void InitWeaponUI() {
		weaponUICanvas = Instantiate(canvasPrefab);
		weaponUI.Add(Instantiate(weaponUIPrefab, weaponUICanvas.transform));
		//개수 맞게 수정
	}
}
