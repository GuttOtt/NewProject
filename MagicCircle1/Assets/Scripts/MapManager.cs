using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space {
    public Stake stake;
    public List<Monster> monsters = new List<Monster>();
    public bool ifCleared = false;
}

public class Stake {
    public int state; // 0 = 꺼짐 / 1 = 켜짐 / 2 = 마법진으로 활성화됨

    public Stake() {
        state = 0;
    }

    public void TurnOn() {
        state = 1;
    }

    public void TurnOff() {
        state = 0;
    }
}


public class MapManager : Singleton<MapManager> {
    public int mapSize;
    public Space[,] map;
    public Space presentSpace;
    public int xStartLocation = 0;//디버그용
    public int yStartLocation = 0;//디버그용

    protected override void Awake() {  
        base.Awake();
        Initialize();
    }

    void Update() {
        //For Debug
        if (Input.GetKeyDown(KeyCode.Y)) {
            MoveToSpace(map[0, 1]);
        }
    }

    private void Initialize() {
        map = new Space[mapSize, mapSize];

        for (int i = 0; i < mapSize; i++) {
            for (int j = 0; j < mapSize; j++){
                map[i, j] = new Space();
                map[i, j].stake = new Stake();
            }
        }

        presentSpace = map[xStartLocation, yStartLocation];
    }

    public void MoveToSpace(Space space) {
        presentSpace = space;

        GameManager.Instance.LoadNewScene();
    }

    public int GetXOf(Space space) {
        for (int i = 0; i < mapSize; i++) {
            for (int j = 0; j < mapSize; j++){
                if (space == map[i, j]) {
                    return j;
                }
            }
        }
        
        return -1;
    }

    public int GetYOf(Space space) {
        for (int i = 0; i < mapSize; i++) {
            for (int j = 0; j < mapSize; j++){
                if (space == map[i, j]) {
                    return i;
                }
            }
        }
        
        return -1;
    }
}
