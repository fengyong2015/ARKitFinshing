using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNetControl : MonoBehaviour
{
	public static FishingNetControl Create (Vector3 pMouse, Vector3 pZ)
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

	public void Init (Vector3 pMouse, Vector3 pZ)
	{
		Vector3 tScreenPos = Camera.main.WorldToScreenPoint (pZ);

		transform.position = Camera.main.ScreenToWorldPoint (pMouse);
		transform.rotation = Camera.main.transform.rotation;

		pMouse.z = tScreenPos.z;
		mTargetPos = Camera.main.ScreenToWorldPoint (pMouse);

		LeanTween.move (gameObject, mTargetPos, 2f).setOnComplete (() => {
			Destroy (gameObject);
		});
	}

	void OnTriggerEnter (Collider other)
	{
		LeanTween.cancel (gameObject);
		if (other.tag.Equals ("fish")) {
			gameObject.transform.SetParent (other.transform);
			FlyGold (other.transform.parent.gameObject);
		}
	}

	void FlyGold (GameObject pGo)
	{
		GameFish tGameFish = pGo.GetComponentInChildren<GameFish> ();
		if (tGameFish != null) {
			StartCoroutine (tGameFish.FishDie ());
		}
	}
}
