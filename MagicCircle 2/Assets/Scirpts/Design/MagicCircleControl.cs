using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleControl : MonoBehaviour, IInteractable {
	public MagicCircle _magicCircle;
	
	public MagicCircle magicCircle {
		get { return _magicCircle; }
		set { _magicCircle = value; }
	}

	public void OnInteract() {
		MagicCircleManager.Instance.AddToInventory(_magicCircle);

		Destroy(this.gameObject);
	}
}