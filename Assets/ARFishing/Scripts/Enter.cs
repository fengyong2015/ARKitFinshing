using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{

	void OnCollisionEnter (Collision other)
	{
		Debug.LogError ("OnCollisionEnter : " + transform.gameObject.name + "------" + other.gameObject.name);
	}

	void OnCollisionStay (Collision other)
	{
		Debug.LogError ("OnCollisionStay : " + transform.gameObject.name + "------" + other.gameObject.name);
	}

	void OnCollisionExit (Collision other)
	{
		Debug.LogError ("OnCollisionExit : " + transform.gameObject.name + "------" + other.gameObject.name);
	}


	void OnTriggerEnter (Collider other)
	{
		Debug.LogError ("OnTriggerEnter : " + transform.gameObject.name + "------" + other.gameObject.name);
	}

	void OnTriggerStay (Collider other)
	{
		Debug.LogError ("OnTriggerStay : " + transform.gameObject.name + "------" + other.gameObject.name);
	}

	void OnTriggerExit (Collider other)
	{
		Debug.LogError ("OnTriggerExit : " + transform.gameObject.name + "------" + other.gameObject.name);
	}
}
