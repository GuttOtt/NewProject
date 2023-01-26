using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagic {
	void Activate();
}



public class MagicTypeHealing: MonoBehaviour, IMagic {
	public float healing;	

	public void Activate() {

	}
}

public class MagicTypeSummon: MonoBehaviour, IMagic {

	public void Activate() {

	}
}