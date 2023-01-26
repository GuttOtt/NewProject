using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponType {
	void Use();
}

public class WeaponTypeGun: IWeaponType {
	public Projectile proj;	

	public void Use() {
		//proj น฿ป็
	}
}