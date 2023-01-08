using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BoxCollider2D, Trigger On
//플레이어가 충돌했을 시 해당 space로 이동시킨다
//MapManager로부터 생성됨
//충돌 시 MapManager.MoveScene을 호출

public class Portal : MonoBehaviour {
	public Space space;
	/* {-1, -1} {-1, 0} {-1, 1}
	   {0, -1}  {0, 0}  {0, 1}
	   {1, -1}  {1, 0}  {1, 1}*/
	public int xPortalLocation;
	public int yPortalLocation;

	private void Start() {
		GetSpace();
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player" && space != null) {
			MapManager.Instance.MoveToSpace(space);
		}
	}

	private void GetSpace() {
		Space presentSpace = MapManager.Instance.presentSpace;
		int xPresentLocation = MapManager.Instance.GetXOf(presentSpace);
		int yPresentLocation = MapManager.Instance.GetYOf(presentSpace);
		
		int xSpace = xPortalLocation + xPresentLocation;
		int ySpace = yPortalLocation + yPresentLocation;

		//현재 위치에서 해당 포탈로 이동할 수 없다면
		if (xSpace < 0 || MapManager.Instance.mapSize == xSpace
			|| ySpace < 0 || MapManager.Instance.mapSize == ySpace) {
			space = null;
			gameObject.SetActive(false);
		}
		else {

			space = MapManager.Instance.map[ySpace, xSpace];
		}
	}
}