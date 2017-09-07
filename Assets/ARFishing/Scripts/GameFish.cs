
using UnityEngine;

public class GameFish:MonoBehaviour
{
	public static GameFish Create (FishType pFinshType, Transform pTrans, Transform pScreenCenter)
	{
		string tFishPath = string.Format ("fish/{0}", pFinshType.ToString ());
		GameObject tFish = Resources.Load<GameObject> (tFishPath);
		tFish = Instantiate (tFish, pTrans);
		GameFish tGameFish = tFish.AddComponent<GameFish> ();
		tGameFish.Init (pFinshType, pScreenCenter);
		return tGameFish;
	}

	public FishType fishType;
	public Animator animator;

	Collider mCollider;
	[HideInInspector]
	public  RatateMove mRatateMove;

	void Init (FishType pFinshType, Transform pStateZ)
	{
		fishType = pFinshType;
		animator = transform.GetComponent<Animator> ();

		mRatateMove = transform.gameObject.AddComponent<RatateMove> ();
		mRatateMove.ScreenCenter = pStateZ;
		mCollider = transform.GetComponentInChildren<Collider> ();
		float tSpeed = mRatateMove.GetSpeed ();
		if (tSpeed > 0.5f) {
			tSpeed = 0;
		} else {
			tSpeed = 1;
		}
		transform.localScale = Vector3.one * Random.Range (0.02f, 0.04f);
		SetMoveSpeed (tSpeed);
		SetPosition (pFinshType);
	}

	public void SetMoveSpeed (float tSpeed)
	{
		animator.SetFloat ("run", tSpeed);
	}

	void SetPosition (FishType pFinshType)
	{
		//球心坐标
		Vector3 tCenter = new Vector3 (0, -1f, 0);
		//球半径
		float tRandio = Random.Range (1, 3f);
		if (pFinshType == FishType.shayu || pFinshType == FishType.jinqiangyu) {
			tRandio = 3;
		}

		Vector3 tNewpos = Random.insideUnitSphere * tRandio + tCenter;
		tNewpos.y = Mathf.Abs (tNewpos.y);
		transform.position = tNewpos;
	}

	void OnCollisionEnter (Collision other)
	{
		Debug.LogError (transform.gameObject.name + "------" + other.gameObject.name);
	}

}
