using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
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
	}


}
