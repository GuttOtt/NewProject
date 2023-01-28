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
		MagicWeapon basicWeapon = Instantiate(basicWeaponPrefab);
		AddWeapon(basicWeapon);
	}

	public void AddWeapon(MagicWeapon weapon) {
		weapon.transform.SetParent(this.transform);
		weapon.transform.localPosition = Vector2.zero;
		weapons.Add(weapon);

		UIAssign(weapons.Count - 1, weapon);
	}

	private void UIAssign(int slotNumber, MagicWeapon weapon) {
		weaponUI[slotNumber].AssignWeapon(weapon);
		weapon.AssignUI(weaponUI[slotNumber]);
	}

	private void InitWeaponUI() {
		weaponUICanvas = Instantiate(canvasPrefab);
		DontDestroyOnLoad(weaponUICanvas);
		for (int i = 0; i < numberOfSlot; i++) {
			weaponUI.Add(Instantiate(weaponUIPrefab, weaponUICanvas.transform));
			weaponUI[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((-numberOfSlot + i) * 100, 50);
		}

	}
}
