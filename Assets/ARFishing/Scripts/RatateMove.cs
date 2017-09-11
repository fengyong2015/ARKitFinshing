using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatateMove : MonoBehaviour
{
	float mSpeed = 10f, mMinSpeed = 5, mMaxSpeed = 20;
	Vector3 mOriginPosition;

	bool tDir = false;

	bool _IsShowing = false;

	public bool isShowing{ get { return _IsShowing; } set { _IsShowing = value; } }

	public bool StopMove = false;

	void Start ()
	{
		mOriginPosition = transform.position;
		Random.seed = gameObject.GetInstanceID ();
		if (Random.value > 0.5f) {
			tDir = true;
		}
	}

	public Transform ScreenCenter;

	void Update ()
	{
		if (!StopMove) {
			if (isShowing) {
				Vector3 tShowingPos = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, ScreenCenter.position.z));
				transform.position = Vector3.MoveTowards (transform.position, tShowingPos, 0.01f);
				transform.forward = Vector3.Lerp (transform.forward, Camera.main.transform.position - transform.position, Time.deltaTime);
				transform.Rotate (new Vector3 (0, 90, 0));
			} else {
				Vector3 tCenter = new Vector3 (0, transform.position.y, 0);
				if (tDir) {
					transform.RotateAround (tCenter, Vector3.up, Time.deltaTime * mSpeed);
					transform.forward = tCenter - transform.position;
				} else {
					transform.RotateAround (tCenter, Vector3.down, Time.deltaTime * mSpeed);
					transform.forward = transform.position - tCenter;
				}
			}
		}
	}

	public float GetSpeed ()
	{
		return (mSpeed - mMinSpeed) / mMaxSpeed;
	}
}
