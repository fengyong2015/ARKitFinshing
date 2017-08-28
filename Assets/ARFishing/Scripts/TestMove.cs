using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{

	List<FishType> tFishTypes = new List<FishType> (System.Enum.GetValues (typeof(FishType))as FishType[]);

	void Start ()
	{
		tFishTypes = new List<FishType> (System.Enum.GetValues (typeof(FishType))as FishType[]);
		tFishTypes.Remove (FishType.None);
		for (int i = 0; i < 100; i++) {
			Create ();
		}
	}

	public void Create ()
	{
		GameFish tFish = GameFish.Create (tFishTypes [Random.Range (0, tFishTypes.Count)], transform);
		tFish.gameObject.AddComponent<RatateMove> ();
		tFish.transform.localScale = Vector3.one * 0.02f;
		SetPosition (tFish.transform);
	}

	public void Attack ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.SendMessage ("OnBeAttacked");
		}
	}

	void SetPosition (Transform pTrans)
	{
//		Vector2 p = Random.insideUnitCircle * 3;  
//		Vector2 pos = p.normalized * (2 + p.magnitude);  
//		Vector3 pos2 = new Vector3 (pos.x, Random.Range (0, 2f) - Random.Range (0, 1) - Random.Range (0, 0.5f), pos.y); 
//		pTrans.position = pos2;

		//球心坐标
		Vector3 tCenter = Vector3.zero;
		//球半径
		float tRandio = Random.Range (2f, 3.5f);
		Vector3 tNewpos = Random.insideUnitSphere * tRandio + tCenter;
		tNewpos.y = Mathf.Abs (tNewpos.y);
		pTrans.position = tNewpos;
	}
}
