using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapManager : Singleton<MapManager> {
	public int xMapSize, yMapSize;
	public Space[,] map;
	public int xStartLocation = 0;
	public int yStartLocation = 0;
	public Space presentSpace;

	public SpaceMono spaceMono;
	public StakeMono stakeMono;

	protected override void Awake() {
		base.Awake();
		Initialize();
	}

	private void Initialize() {
		spaceMono = GetComponent<SpaceMono>();
		stakeMono = GetComponent<StakeMono>();

        map = new Space[yMapSize, xMapSize];

        for (int i = 0; i < yMapSize; i++) {
            for (int j = 0; j < xMapSize; j++){
				map[i, j] = new Space(j, i);

				if (i == yStartLocation && j == xStartLocation) {
					map[i, j].ReplacePlayer();
				}
            }
        }
    }

}