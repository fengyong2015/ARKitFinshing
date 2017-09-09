using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameBaseButton : Button
{
	Vector3 m_OriginScale;

	protected override void Start ()
	{
		base.Start ();
		m_OriginScale = transform.localScale;
	}

	public override void OnPointerDown (PointerEventData eventData)
	{
		LeanTween.scale (gameObject, m_OriginScale * 1.1f, 0.3f);
	}

	public override void OnPointerUp (PointerEventData eventData)
	{
		LeanTween.scale (gameObject, m_OriginScale, 0.3f);
	}

	public override void OnPointerClick (PointerEventData eventData)
	{
		base.OnPointerClick (eventData);
	}
}
