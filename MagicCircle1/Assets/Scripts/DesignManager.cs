using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignManager : MonoBehaviour
{
    public GameObject stakeMarkerPrefab;

    List<GameObject> stakeMarkers = new List<GameObject>();

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D ray = Physics2D.Raycast(mousePos, Vector2.zero);    
               
                if (ray.collider != null && ray.collider.tag == "Design") {
                    Design design = ray.collider.gameObject.GetComponent<Design>();
                    Stake[,] matchingStakes = design.matchingStakes;

                    for (int i = 0; i < matchingStakes.GetLength(0); i++) {
                        for (int j = 0; j < matchingStakes.GetLength(1); j++) {
                            Stake stake = matchingStakes[i, j];
                            if (stake != null && stake.state == 1)
                                stakeMarkers.Add(Instantiate(stakeMarkerPrefab, stake.transform.position, Quaternion.identity));
                        }
                    }
                }
        }

        if (Input.GetMouseButtonUp(1)) {
            foreach (GameObject marker in stakeMarkers) {
                Destroy(marker);
            }
        }
    }
}
