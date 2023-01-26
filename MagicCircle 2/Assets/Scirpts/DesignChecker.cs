using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Array2DEditor;

public class DesignChecker {

    public static Space[,] CorrespondingSpaces(MagicCircle magicCircle){
        Array2DInt design = magicCircle.data.design;
        int xLength = design.GridSize.x;
        int yLength = design.GridSize.y;
        int xNumberOfCheck = MapManager.Instance.xMapSize - xLength + 1;
        int yNumberOfCheck = MapManager.Instance.yMapSize - yLength + 1;
        Space[,] checkTarget = new Space[yLength, xLength];

        for (int i = 0; i < yNumberOfCheck; i++){
            for (int j = 0; j < xNumberOfCheck; j++) {
                checkTarget = GetCopy(j, i, xLength, yLength);

                if (CompareSpacesDesign(checkTarget, design)) {
                    return checkTarget;
                }
            }
        }

        Debug.Log("returned null");
        return null;
    }

    private static bool CompareSpacesDesign(Space[,] spaces, Array2DInt design) {
        if (spaces.GetLength(0) != design.GridSize.x || spaces.GetLength(1) != design.GridSize.y) {
            
            return false;
        }

        for (int y = 0; y < spaces.GetLength(0); y++) {
            for (int x = 0; x < spaces.GetLength(1); x++) {
                if (spaces[y, x].stake.CurrentStateInt != design.GetCell(x, y)) {
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