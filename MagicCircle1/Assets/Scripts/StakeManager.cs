using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeManager : MonoBehaviour
{
    public int mapSize;
    public Stake stakePrefab;
    public int stakeSize; 
    public List<Design> designs = new List<Design>();
    //public int maxDesignSize;

    Stake[,] stakeMap;

    void Start() {  
        stakeMap = new Stake[mapSize, mapSize];
        Vector3 stakePos;

        for (int i = 0; i < mapSize; i++) {
            for (int j = 0; j < mapSize; j++) {
                stakePos = transform.position + new Vector3(stakeSize * j, -stakeSize * i, 0);
                stakeMap[i, j] = Instantiate(stakePrefab, stakePos, Quaternion.identity);
            }
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D ray = Physics2D.Raycast(mousePos, Vector2.zero);
            Stake clickedStake;

            if (ray.collider != null) {
                if (ray.collider.tag == "Stake") {
                    clickedStake = ray.collider.gameObject.GetComponent<Stake>();

                    if (clickedStake.state == 0) {
                        clickedStake.TurnOn();
                    }
                    else if (clickedStake.state == 1) {
                        clickedStake.TurnOff();
                    }

                    foreach (Design design in designs) {
                        design.ClearMatchingStakes();
                        CheckDesignExist(design);
                    }
                }
            }
        }
    }

    private void CheckDesignExist(Design design){
        int xLength = design.design.GetLength(1);
        int yLength = design.design.GetLength(0);
        int xNumberOfCheck = mapSize - xLength + 1;
        int yNumberOfCheck = mapSize - yLength + 1;

        for (int i = 0; i < yNumberOfCheck; i++){
            for (int j = 0; j < xNumberOfCheck; j++) {
                Stake[,] checkTarget = GetCopy(j, i, xLength, yLength);
                if (CompareStakesInts(checkTarget, design.design)) {
                    design.matchingStakes = checkTarget;
                }
            }
        }
    }

    private bool CompareStakesInts(Stake[,] stakes, int[,] ints){
        if (stakes.GetLength(0) != ints.GetLength(0) || stakes.GetLength(1) != ints.GetLength(1)) {
            return false;
        }

        for (int i = 0; i < stakes.GetLength(0); i++) {
            for (int j = 0; j < stakes.GetLength(1); j++) {
                if (stakes[i, j].state != ints[i, j]) {
                    return false;
                }
            }
        }

        return true;
    }
    
    
    private Stake[,] GetCopy(int xOrigin, int yOrigin, int xLength, int yLength) {
        Stake[,] copy = new Stake[yLength, xLength];

        for (int i = 0; i < yLength; i++) {
            for (int j = 0; j < xLength; j++) {
                copy[i, j] = stakeMap[i + yOrigin, j + xOrigin];
            }
        }
        
        return copy;
    }

    /* 일시 삭제
    private int[,] GetCheckTarget(int originX, int originY, int size) {
        int[,] checkTarget = new int[size, size];

        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                checkTarget[i, j] = stakeMap[originX + i, originY +j].state;
            }
        }
        
        return checkTarget;
    }
    
    private bool IfArraySame(int[,] array1, int[,] array2) {
        if (array1.GetLength(0) != array2.GetLength(0) || array1.GetLength(1) != array2.GetLength(1)) {
            return false;
        }

        for (int i = 0; i < array1.GetLength(0); i++) {
            for (int j = 0; j < array1.GetLength(1); j++) {
                if (array1[i, j] != array2[i, j]) {
                    return false;
                }
            }
        }

        return true;
    }
    */
}
