using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleManager : Singleton<MagicCircleManager> {
	public MagicCircleControl magicCircleControlPrefab;

	public List<MagicCircle> magicCircleAll;
    public List<MagicCircle> magicCircleInventory; //PlayerMagicInventory·Î ±¸ºÐ?

	private void Update() {
		if (Input.GetKeyDown(KeyCode.G)) {
			int randomIndex = Random.Range(0, magicCircleAll.Count);
			MakeMagicCircleControl(magicCircleAll[randomIndex]);
		}
	}

	public void MakeMagicCircleControl(MagicCircle magicCircle) {
		MagicCircleControl newControl = Instantiate(magicCircleControlPrefab);
		newControl.magicCircle = magicCircle;
	}

	public void AddToInventory(MagicCircle magicCircle) {
		magicCircleInventory.Add(magicCircle);
	}
}
