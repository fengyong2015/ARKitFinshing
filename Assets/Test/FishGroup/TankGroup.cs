//write by shadow
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TankGroup : MonoBehaviour
{
	private static List<TankGroup> tankGroups;
	//所有组
	
	public LayerMask mask;
	//成员层
	public int groupID = 0;
	//组id
	public float keepDistance = 10, keepWeight = 1;
	//成员保持距离和保持距离权重
	public float targetCloseDistance = 20, targetWeight = 1.25f, moveWeight = 0.8f;
	//距离目标距离，距离目标权重和成员移动权重
	//~ public Color color=Color.green;

	//位置
	public Vector3 targetPosition {
		get{ return transform.position; }
	}

	public static void AddGroup (TankGroup group)
	{
		if (tankGroups == null)
			tankGroups = new List<TankGroup> ();
		
		if (!tankGroups.Contains (group))
			tankGroups.Add (group);
	}

	public static TankGroup GetTankGroup (int index)
	{
		if (tankGroups == null)
			tankGroups = new List<TankGroup> (Object.FindObjectsOfType (typeof(TankGroup))as TankGroup[]);
		
		for (int i = 0; i < tankGroups.Count; i++)
			if (tankGroups [i].groupID == index)
				return tankGroups [i];
		
		throw new System.Exception ("groupID not find");
	}

	void Update ()
	{
		Vector3 tCenter = new Vector3 (0, 1, 0);
		transform.RotateAround (tCenter, Vector3.up, Time.deltaTime * Random.Range (0, 50));
	}
}
