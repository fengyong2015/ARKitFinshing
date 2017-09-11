using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldNumControl : MonoBehaviour {

    Text goldText;

	void Start () {
		
        goldText = GetComponentInChildren<Text>();
	}
	
	void Update () {

        goldText.text = GameData.Instance.CoinNum.ToString();
		
	}
}
