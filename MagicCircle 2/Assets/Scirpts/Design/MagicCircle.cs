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

		//�κ��丮���� �ڽ��� ����
		//UI ������Ʈ
		MagicCircleManager.Instance.magicCircleInventory.Remove(this);
		MagicCircleUIManager.Instance.UpdateUI();
	}
}