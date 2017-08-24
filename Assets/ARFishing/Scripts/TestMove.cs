using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
	
	//	// Update is called once per frame
	//	void Update ()
	//	{
	//		transform.RotateAround (new Vector3 (0, 1, 0), Vector3.up, 30 * Time.deltaTime);
	//	}
	//
	//
	public void Create ()
	{
		List<FishType> tFishTypes = new List<FishType> (System.Enum.GetValues (typeof(FishType))as FishType[]);
		tFishTypes.Remove (FishType.None);
		GameFish.Create (tFishTypes [Random.Range (0, tFishTypes.Count)], transform);
	}

	public void Attack ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.SendMessage ("OnBeAttacked");
		}
	}
}
