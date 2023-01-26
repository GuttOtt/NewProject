using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

public class MagicCircle : MonoBehaviour {
	public MagicCircleData data;
	public Sprite designSprite;

	public void Complete() {
		IMagic magic = GetComponent<IMagic>();

		magic.Activate();

		//인벤토리에서 자신을 삭제
		//UI 업데이트
		MagicCircleManager.Instance.magicCircleInventory.Remove(this);
		MagicCircleUIManager.Instance.UpdateUI();
	}
}