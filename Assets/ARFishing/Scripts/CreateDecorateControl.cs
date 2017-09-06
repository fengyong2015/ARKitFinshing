using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class CreateDecorateControl : MonoBehaviour {


    void Start(){

        UnityARSessionNativeInterface.ARAnchorAddedEvent += OnAnchorAdder;
    }

    void OnDestory(){

        UnityARSessionNativeInterface.ARAnchorAddedEvent -= OnAnchorAdder;

    }

    void OnAnchorAdder(ARPlaneAnchor anchorData){

        GameObject decorate = Instantiate(Resources.Load(getRandomDecorate()) as GameObject);
        decorate.transform.parent = transform;
        decorate.transform.position = UnityARMatrixOps.GetPosition (anchorData.transform);
        decorate.transform.rotation = UnityARMatrixOps.GetRotation (anchorData.transform);
        decorate.transform.localScale = Vector3.one * 10f;
    }

    string getRandomDecorate(){

        string[] allDecorate = new string[]
        {
            "haicao_001",
            "haicao_002",
            "haidai",
            "haixing",
            "haizhe",
            "shitou"
        };

        return "decorate/" + allDecorate [Random.Range(0, allDecorate.Length)];
    }
}
