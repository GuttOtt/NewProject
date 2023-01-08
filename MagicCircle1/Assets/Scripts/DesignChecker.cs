using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignChecker {

    public static Space[,] CorrespondingSpaces(CircleDesign design){
        int xLength = design.design.GetLength(1);
        int yLength = design.design.GetLength(0);
        int xNumberOfCheck = MapManager.Instance.mapSize - xLength + 1;
        int yNumberOfCheck = MapManager.Instance.mapSize - yLength + 1;
        Space[,] checkTarget = new Space[yLength, xLength];

        for (int i = 0; i < yNumberOfCheck; i++){
            for (int j = 0; j < xNumberOfCheck; j++) {
                checkTarget = GetCopy(j, i, xLength, yLength);

                if (CompareSpacesDesign(checkTarget, design.design)) {
                    return checkTarget;
                }
            }
        }

        return null;
    }

    private static bool CompareSpacesDesign(Space[,] spaces, int[,] design){
        if (spaces.GetLength(0) != design.GetLength(0) || spaces.GetLength(1) != design.GetLength(1)) {
            return false;
        }

        for (int i = 0; i < spaces.GetLength(0); i++) {
            for (int j = 0; j < spaces.GetLength(1); j++) {
                if (spaces[i, j].stake.state != design[i, j]) {
                    return false;
                }
            }
        }

        return true;
    }
    
    
    private static Space[,] GetCopy(int xOrigin, int yOrigin, int xLength, int yLength) {
        Space[,] copy = new Space[yLength, xLength];

        for (int i = 0; i < yLength; i++) {
            for (int j = 0; j < xLength; j++) {
                copy[i, j] = MapManager.Instance.map[i + yOrigin, j + xOrigin];
            }
        }
        
        return copy;
    }
}
