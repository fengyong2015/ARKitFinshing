using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpearControl : MonoBehaviour
{
	public static FishSpearControl Create (Vector2 pScreenPoint)
	{
		FishSpearControl tCtrl = Resources.Load<FishSpearControl> ("");
		tCtrl.Init (pScreenPoint);
		return tCtrl;
	}

	Vector3 mTargetPos;
	Vector3 mOriginPos;

	public void Init (Vector2 pScreenPoint)
	{
		mOriginPos = Camera.main.transform.position;
		transform.position = mOriginPos;
		mTargetPos = Camera.main.ScreenToWorldPoint (new Vector3 (pScreenPoint.x, pScreenPoint.y, 10));
	}

	void Update ()
	{
		transform.position = Vector3.Lerp (mOriginPos, mTargetPos, Time.deltaTime);
	}
}
