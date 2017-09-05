using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNetControl : MonoBehaviour
{
	public static FishingNetControl Create (Vector3 pMouse, float pZ)
	{
		GameObject tFishingNet = Resources.Load<GameObject> ("yuwang");
		tFishingNet = Instantiate (tFishingNet);
		tFishingNet.transform.localScale = Vector3.one * 2;
		tFishingNet.transform.localEulerAngles = new Vector3 (-90f, 0, -180f);
		tFishingNet.name = "yuwang";
		FishingNetControl tCtrl = tFishingNet.GetComponent<FishingNetControl> ();
		tCtrl.Init (pMouse, pZ);
		return tCtrl;
	}

	Vector3 mTargetPos;
	Vector3 mOriginPos;

	public void Init (Vector3 pMouse, float pZ)
	{
		mOriginPos = Camera.main.transform.position;
		transform.position = mOriginPos;
		transform.rotation = Camera.main.transform.rotation;
		mTargetPos = Camera.main.ScreenToWorldPoint (new Vector3 (pMouse.x, pMouse.y, pZ));
		mTargetPos.z = pZ;
	}

	void Update ()
	{
		transform.position = Vector3.Lerp (transform.position, mTargetPos, Time.deltaTime / 3f);
		if (Vector3.Distance (mTargetPos, transform.position) < 2f) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag.Contains ("fish")) {
			Destroy (transform.gameObject);
			Destroy (other.transform.gameObject);
		}
	}
}
