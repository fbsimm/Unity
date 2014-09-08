using UnityEngine;
using System.Collections;

public class initScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Score", 0);
		GUICamera.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
