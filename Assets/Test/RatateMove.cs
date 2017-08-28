using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatateMove : MonoBehaviour
{
	float mSpeed = 10f;
	Vector3 mOriginPosition;
	// Use this for initialization
	void Start ()
	{
		mOriginPosition = transform.position;
		mSpeed = Random.Range (5, 10);
	}


	// Update is called once per frame
	void Update ()
	{
		Vector3 tCenter = new Vector3 (0, transform.position.y, 0);
		transform.RotateAround (tCenter, Vector3.up, Time.deltaTime * mSpeed);
		transform.LookAt (tCenter, Vector3.up);

	}
}
