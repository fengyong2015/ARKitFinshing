using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBubbleControl : MonoBehaviour
{
	[SerializeField]
	GameObject m_Bubble;

	[SerializeField]
	Transform m_Orign;

	void Start ()
	{
		StartCoroutine (ProduceBubble ());
	}

	IEnumerator ProduceBubble ()
	{
		while (true) {
//			yield return new WaitForSeconds (Random.Range (15, 30));
			yield return new WaitForSeconds (Random.Range (5, 10));
			StartCoroutine (CreateBubble ());
		}
	}

	IEnumerator CreateBubble ()
	{
//		Transform tTrans = m_Parent [Random.Range (0, m_Parent.Length)];
		float tZ = m_Orign.transform.position.z;
		Vector3 tV3 = Camera.main.ViewportToWorldPoint (new Vector3 (Random.value, 0, tZ));

		GameObject bubble = Instantiate (m_Bubble);
		bubble.transform.position = tV3;
		yield break;
		yield return new WaitForSeconds (Random.Range (30, 50));
		Destroy (bubble);
	}
}
