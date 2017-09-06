using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
	[SerializeField]
	Transform m_Trans;

	List<FishType> tFishTypes = new List<FishType> (System.Enum.GetValues (typeof(FishType))as FishType[]);

	void Start ()
	{
		tFishTypes = new List<FishType> (System.Enum.GetValues (typeof(FishType))as FishType[]);
		tFishTypes.Remove (FishType.None);
		for (int i = 0; i < 50; i++) {
			Create ();
		}
	}

	public void Create ()
	{
		GameFish tFish = GameFish.Create (tFishTypes [Random.Range (0, tFishTypes.Count)], transform);
//		GameFish tFish = GameFish.Create (FishType.xiaochouyu, transform);
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			
			FishingNetControl.Create (Input.mousePosition, m_Trans.position);
		}
	}

	public void Fire ()
	{
		Debug.LogError ("Fire");
//		FishSpearControl.Create ();
	}


}
