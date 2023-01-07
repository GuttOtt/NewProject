using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignManager : Singleton<DesignManager> {
    public List<CircleDesign> allDesigns;
    public List<CircleDesign> ownedDesigns;
    public GameObject stakeMarkerPrefab;

    List<GameObject> stakeMarkers = new List<GameObject>();


    
}
