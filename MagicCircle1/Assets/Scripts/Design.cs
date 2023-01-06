using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Design : MonoBehaviour
{
	[Serializable]
	public class Array2D {
		public int[] array2D;
	}

	public Array2D[] designArray;
	public int[,] design;
	public Stake[,] matchingStakes = null;
	public GameObject blankPrefabW;
	public GameObject blankPrefabB;
	public float blankSize;
	public bool randomize;

	int xLength;
	int yLength;

	void Start() {
		yLength = designArray.Length;
		xLength = designArray[0].array2D.Length;
		
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

		DrawDesign();
	}

	private void DrawDesign() {
		Vector3 pos;
		for (int i = 0; i < yLength; i++) {
			for (int j = 0; j < xLength; j++) {
				pos = new Vector3(j * blankSize, -i * blankSize, 0);
				GameObject newBlank;

				if (design[i, j] == 0) {
					newBlank = Instantiate(blankPrefabW, this.transform);
					newBlank.transform.localPosition += pos;

				}
				else {
					newBlank = Instantiate(blankPrefabB, this.transform);
					newBlank.transform.localPosition += pos;
				}
			}
		}

		BoxCollider2D col = GetComponent<BoxCollider2D>();
		float xOffset = (xLength - 1) / 2 * blankSize;
		float yOffset = -(yLength - 1) / 2 * blankSize;
		col.offset = new Vector2(xOffset, yOffset);
		col.size = new Vector2(xLength * blankSize, yLength * blankSize);
	}

	public void ClearMatchingStakes() {
		for (int i = 0; i < matchingStakes.GetLength(0); i++) {
			for (int j = 0; j < matchingStakes.GetLength(1); j++) {
				matchingStakes[i, j] = null;
			}
		}
	}

	private void Randomize() {
		for (int i = 0; i < design.GetLength(0); i++) {
			for (int j = 0; j < design.GetLength(1); j++) {
				design[i, j] = (int) Mathf.Round(UnityEngine.Random.Range(0f, 1f));
			}
		}
	}
}
