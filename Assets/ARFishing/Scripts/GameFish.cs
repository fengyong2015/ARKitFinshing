
using UnityEngine;

public class GameFish:MonoBehaviour
{
	public static GameFish Create (FishType pFinshType, Transform pTrans)
	{
		string tFishPath = string.Format ("fish/{0}", pFinshType.ToString ());
		GameObject tFish = Resources.Load<GameObject> (tFishPath);
		tFish = Instantiate (tFish, pTrans);
		GameFish tGameFish = tFish.AddComponent<GameFish> ();
		tGameFish.Init (pFinshType);
		return tGameFish;
	}

	public FishType fishType;
	public Animator animator;

	Collider mCollider;

	void Init (FishType pFinshType)
	{
		fishType = pFinshType;
		animator = transform.GetComponent<Animator> ();

		RatateMove tRatateMove = transform.gameObject.AddComponent<RatateMove> ();
		float tSpeed = tRatateMove.GetSpeed ();
		if (tSpeed > 0.5f) {
			tSpeed = 0;
		} else {
			tSpeed = 1;
		}
		transform.localScale = Vector3.one * Random.Range (0.02f, 0.04f);
		SetMoveSpeed (tSpeed);
		SetPosition ();
	}

	public void SetMoveSpeed (float tSpeed)
	{
		animator.SetFloat ("run", tSpeed);
	}

	void SetPosition ()
	{
		//球心坐标
		Vector3 tCenter = Vector3.zero;
		//球半径
		float tRandio = Random.Range (1, 3f);
		Vector3 tNewpos = Random.insideUnitSphere * tRandio + tCenter;
		tNewpos.y = Mathf.Abs (tNewpos.y);
		transform.position = tNewpos;
	}

	void OnCollisionEnter (Collision other)
	{
		Debug.LogError (transform.gameObject.name + "------" + other.gameObject.name);
	}

}
