
using UnityEngine;

public class GameFish:MonoBehaviour
{
	public static GameFish Create (FishType pFinshType, Transform pTrans)
	{
		string tFishPath = string.Format ("fish/{0}", pFinshType.ToString ());
		GameObject tFish = Resources.Load<GameObject> (tFishPath);
		Debug.LogError (tFishPath);
		tFish = Instantiate (tFish, pTrans);
		GameFish tGameFish = tFish.AddComponent<GameFish> ();
		tGameFish.Init (pFinshType);
		return tGameFish;
	}

	FishType fishType;

	public FishType FishType {
		get {
			return fishType;
		}
	}

	Animator animator;

	public Animator Animator {
		get {
			return animator;
		}
	}

	void Init (FishType pFinshType)
	{
		fishType = pFinshType;
		animator = transform.GetComponent<Animator> ();
	}

	//速度 每秒移动速度
	float _MoveSpeed = 0.05f;
	float minMoveSpeed = 0.05f;
	float maxMoveSpeed = 1f;

	public float MoveSpeed {
		get {
			return _MoveSpeed;
		}
		set { 
			_MoveSpeed = value;

		}
	}

	public void OnBeAttacked ()
	{
		MoveSpeed = (MoveSpeed + maxMoveSpeed) / 2;
	}

	void LateUpdate ()
	{
		MoveSpeed = Mathf.Lerp (MoveSpeed, minMoveSpeed, Time.deltaTime / 10f);
		transform.position -= new Vector3 (MoveSpeed, 0, 0);
		animator.SetFloat ("run", MoveSpeed / (maxMoveSpeed - minMoveSpeed));
	}

}
