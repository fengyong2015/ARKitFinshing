using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatateMove : MonoBehaviour
{
	float mSpeed = 10f, mMinSpeed = 5, mMaxSpeed = 20;
	Vector3 mOriginPosition;

	void Start ()
	{
		mOriginPosition = transform.position;
		mSpeed = Random.Range (mMinSpeed, mMaxSpeed);
	}


	// Update is called once per frame
	void Update ()
	{
		Vector3 tCenter = new Vector3 (0, transform.position.y, 0);
		transform.RotateAround (tCenter, Vector3.up, Time.deltaTime * mSpeed);
		transform.LookAt (tCenter, Vector3.up);
	}

	public float GetSpeed ()
	{
//		return (mSpeed - mMinSpeed) / (mMaxSpeed - mMinSpeed);
		return (mSpeed - mMinSpeed) / mMaxSpeed;
	}
}
