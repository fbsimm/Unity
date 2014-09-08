using UnityEngine;
using System.Collections;

public class respawner : MonoBehaviour {
	private int level;


	void OnLevelWasLoaded(int curlvl){
		level = curlvl;

	}
	void OnTriggerEnter2D(Collider2D other) {
		PlayerPrefs.SetInt("Score", GUICamera.score);
		Application.LoadLevel("Niveau" + (level+1));		
	}
}
