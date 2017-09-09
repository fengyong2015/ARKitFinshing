using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{

	public void OnStoryTypeClick ()
	{
		SceneManager.LoadScene (1);
	}

	public void OnSingleTypeClick ()
	{
		SceneManager.LoadScene (2);
	}

	public void OnSingleMintleClick ()
	{
		SceneManager.LoadScene (3);
	}
}
