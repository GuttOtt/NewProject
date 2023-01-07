using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDesign : MonoBehaviour
{
	[Serializable]
	public class Array2D {
		public int[] array2D;
	}

	public Array2D[] designArray;
	public int[,] design;
	public Stake[,] matchingStakes = null;
	public bool randomize;

	void Awake() {
		int yLength = designArray.Length;
		int xLength = designArray[0].array2D.Length;
		
		design = new int[yLength, xLength];
		matchingStakes = new Stake[yLength, xLength];

		for (int i = 0; i < yLength; i++) {
			Array2D row = designArray[i];
			for (int j = 0; j < xLength; j++) {
			design[i, j] = row.array2D[j];
			}
		}

		if (randomize)
			Randomize();
	}


	//DebugManager
	private void Randomize() {
		for (int i = 0; i < design.GetLength(0); i++) {
			for (int j = 0; j < design.GetLength(1); j++) {
				design[i, j] = (int) Mathf.Round(UnityEngine.Random.Range(0f, 1f));
			}
		}
	}
}
