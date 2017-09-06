using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatateMove : MonoBehaviour
{
	float mSpeed = 10f, mMinSpeed = 5, mMaxSpeed = 20;
	Vector3 mOriginPosition;

	bool tDir = false;

	void Start ()
	{
		mOriginPosition = transform.position;
		Random.seed = gameObject.GetInstanceID ();
		if (Random.value > 0.5f) {
			tDir = true;
		}
	}

	void Update ()
	{
		Vector3 tCenter = new Vector3 (0, transform.position.y, 0);
		if (tDir) {
			transform.RotateAround (tCenter, Vector3.up, Time.deltaTime * mSpeed);
			transform.forward = tCenter - transform.position;
		} else {
			transform.RotateAround (tCenter, Vector3.down, Time.deltaTime * mSpeed);
			transform.forward = transform.position - tCenter;
		}
	}

	public float GetSpeed ()
	{
		return (mSpeed - mMinSpeed) / mMaxSpeed;
	}
}
