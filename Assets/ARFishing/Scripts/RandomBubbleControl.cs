using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBubbleControl : MonoBehaviour
{
	[SerializeField]
	GameObject m_Bubble;

	[SerializeField]
	Transform[] m_Parent;

	void Start ()
	{
		StartCoroutine (ProduceBubble ());
	}

	IEnumerator ProduceBubble ()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (15, 30));
			StartCoroutine (CreateBubble ());
		}
	}

	IEnumerator CreateBubble ()
	{
		Transform tTrans = m_Parent [Random.Range (0, m_Parent.Length)];
		GameObject bubble = Instantiate (m_Bubble);
		bubble.transform.position = tTrans.position;
		yield break;
		yield return new WaitForSeconds (Random.Range (30, 50));
		Destroy (bubble);
	}
}
