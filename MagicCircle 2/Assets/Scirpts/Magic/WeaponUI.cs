using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour {
	
	[SerializeField] private Image imgFill;
	private MagicWeapon weapon;
	private float coolDown;

	private void Awake() {
		coolDown = 0;
		imgFill = gameObject.GetComponent<Image>();
	}

	public void AssignWeapon(MagicWeapon _weapon) {
		weapon = _weapon;
		imgFill.sprite = weapon.uiImage;
		imgFill.type = Image.Type.Filled;
	}

	public void StartCoolDown(float coolTime) {
		IEnumerator coroutine = CoolDownCoroutine(coolTime);
		StartCoroutine(coroutine);
	}

	private IEnumerator CoolDownCoroutine(float coolTime) {
		coolDown = coolTime;

		while (true) {
			coolDown -= Time.deltaTime;
			imgFill.fillAmount = 1 - (coolDown / coolTime);

			if (coolDown <= 0) {
				break;
			}
			
			yield return null;
		}
	}
}
