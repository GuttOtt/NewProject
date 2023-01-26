using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

[CreateAssetMenu(menuName = "MagicCircleData")]

public class MagicCircleData : ScriptableObject {
	public Array2DInt design;
	public IMagic magic;
}