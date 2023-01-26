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
	public float xDistance = 9;
	public float yDistance = 5;

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player" && space != null) {
			//플레이어 위치 조정
			Vector2 playerLocation = new Vector2(-xPortalLocation * (xDistance - 1.5f), yPortalLocation * (yDistance -1.5f));
			GameObject playerObj = col.gameObject;
			playerObj.transform.position = playerLocation;

			GameManager.Instance.MoveToSpace(space);
		}
	}

	public void Initialize(int x, int y) {
		xPortalLocation = x;
		yPortalLocation = y;

		transform.position = new Vector2(x * xDistance, -y * yDistance);

		GetSpace();
	}

	private void GetSpace() {
		Space presentSpace = MapManager.Instance.presentSpace;
		int xPresentLocation = presentSpace.XIndex;
		int yPresentLocation = presentSpace.YIndex;
		
		int xDestination = xPortalLocation + xPresentLocation;
		int yDestination = yPortalLocation + yPresentLocation;

		//현재 위치에서 해당 포탈로 이동할 수 없다면
		if (xDestination < 0 || MapManager.Instance.xMapSize  == xDestination
			|| yDestination < 0 || MapManager.Instance.yMapSize  == yDestination) {
			space = null;
			gameObject.SetActive(false);
		}
		else {
			space = MapManager.Instance.map[yDestination, xDestination];
		}
	}
}