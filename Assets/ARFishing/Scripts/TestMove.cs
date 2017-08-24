using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround (new Vector3 (0, 1, 0), Vector3.up, 30 * Time.deltaTime);
	}
}
