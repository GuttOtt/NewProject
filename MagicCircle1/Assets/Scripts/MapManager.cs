using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space {
    public Stake stake;
    public List<Monster> monsters = new List<Monster>();
    public bool ifCleared = false;
}

public class Stake {
    public int state; // 0 = ���� / 1 = ���� / 2 = ���������� Ȱ��ȭ��

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

    protected override void Awake() {  
        map = new Space[mapSize, mapSize];

        Initialize();
    }

    void Update() {
    }

    private void Initialize() {
        map = new Space[mapSize, mapSize];

        for (int i = 0; i < mapSize; i++) {
            for (int j = 0; j < mapSize; j++){
                map[i, j] = new Space();
                map[i, j].stake = new Stake();
            }
        }
    }
}
