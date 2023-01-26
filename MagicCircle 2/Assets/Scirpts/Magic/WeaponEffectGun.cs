using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponEffect {
	float CoolTime { get; }
	float CoolDown { get; }
	void TryToUse();
	void Effect();
}

public class WeaponEffectGun : MonoBehaviour, IWeaponEffect {
	public Projectile projPrefab;
	public WeaponUI weaponUI;

	[SerializeField] private float coolTime;
	private float coolDown;
	private float lastUseTime;

	public float CoolTime {
		get => coolTime;
	}

	public float CoolDown {
		get => coolDown;
	}

	private void OnEnable() {
		lastUseTime = -coolTime;
	}

	public void TryToUse() {
        if (lastUseTime + coolTime <= Time.time){
            Effect();
        }
    }

    public void Effect() {
		//Fire projectile
		Vector3 origin = transform.position;
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		float x = mousePos.x;
		float y = mousePos.y;
		Vector3 direction = new Vector3(mousePos.x, mousePos.y, 0) - origin;

		Projectile proj = Instantiate(projPrefab, transform.position, Quaternion.FromToRotation(Vector3.up, direction));

		//CoolDown
        lastUseTime = Time.time;
		gameObject.GetComponent<MagicWeapon>().weaponUI.StartCoolDown(coolTime);
    }
}
