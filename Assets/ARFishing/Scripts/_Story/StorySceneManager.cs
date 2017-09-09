using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneManager : MonoBehaviour
{
	[SerializeField]
	Transform m_Trans;

	[SerializeField]
	Transform m_ScreenCenter;

	List<FishType> tFishTypes = new List<FishType> (System.Enum.GetValues (typeof(FishType))as FishType[]);

	void Start ()
	{
		Create ();
	}

	public void Create ()
	{
		tFishTypes = new List<FishType> (System.Enum.GetValues (typeof(FishType))as FishType[]);
		tFishTypes.Remove (FishType.None);

		foreach (var item in tFishTypes) {
			GameFish.Create (item, transform, m_ScreenCenter);
		}
	}

	bool CanCatch = true;

	void Update ()
	{
		if (CanCatch) {
			if (Input.GetMouseButtonDown (0)) {
				CatchFish (Input.mousePosition);
			}
		}
	}


	GameFish mGameFish;

	void CatchFish (Vector2 pScreenPoint)
	{
		mGameFish = null;

		// 以摄像机所在位置为起点，创建一条向下发射的射线  
		Vector3 tCameraPos = Camera.main.transform.position;
		Vector3 tFarPos = Camera.main.ScreenToWorldPoint (new Vector3 (pScreenPoint.x, pScreenPoint.y, m_Trans.position.z));
		Ray ray = new Ray (tCameraPos, tFarPos - tCameraPos);
		RaycastHit hit;  
		if (Physics.Raycast (ray, out hit, 10f)) {
			mGameFish = hit.collider.transform.parent.GetComponent<GameFish> ();
			if (mGameFish != null) {
				CanCatch = false;
				StartCoroutine (ShowFinish ());
			}
		}
	}

	IEnumerator ShowFinish ()
	{
		mGameFish.mRatateMove.isShowing = true;
		yield return new WaitForSeconds (5f);
	}

	public void Back ()
	{
		SceneManager.LoadScene (0);
	}

}
