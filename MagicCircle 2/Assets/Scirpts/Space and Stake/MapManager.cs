using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapManager : Singleton<MapManager> {
	public int xMapSize, yMapSize;
	public Space[,] map;
	public int xStartLocation = 0;
	public int yStartLocation = 0;
	public Space presentSpace;
	public StakeControl stakeControl;
	public Portal portalPrefab;
	
	public SpaceMono spaceMono;
	public StakeMono stakeMono;

	private void Start() {
		Initialize();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.P)) {
			MoveToSpace(map[0, 1]);
		}
	}

	private void Initialize() {
		spaceMono = GetComponent<SpaceMono>();
		stakeMono = GetComponent<StakeMono>();

        map = new Space[yMapSize, xMapSize];

        for (int i = 0; i < yMapSize; i++) {
            for (int j = 0; j < xMapSize; j++){
				map[i, j] = new Space(j, i);

				if (i == yStartLocation && j == xStartLocation) {
					presentSpace = map[i, j];
				}
            }
        }
		MapUIManager.Instance.Initialize();
		
		

		MakeStakeControl();
		MakePortals();
	}


	public void MakeStakeControl() {
		Debug.Log("MakeStakeControl"+presentSpace.XIndex);
		presentSpace.ContainedStake.MakeControl();
	}

	public void MakePortals() {
		for (int i = -1; i < 2; i++) {
			for (int j = -1; j < 2; j++) {
				if (!(i == 0 && j == 0)) {
					Portal portal = Instantiate(portalPrefab);

					portal.Initialize(i, j);
				}
			}
		}
	}
	
	public void MoveToSpace(Space space) {
        presentSpace = space;
		MakeStakeControl();
		MakePortals();
    }
}