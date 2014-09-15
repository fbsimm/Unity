using UnityEngine;
using System.Collections;

public class GUICamera : MonoBehaviour {
	public GameObject player;
	public static int score = 0;
	// Use this for initialization
	void Awake() {
		//DontDestroyOnLoad(gameObject);
		score = PlayerPrefs.GetInt("Score");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = new Vector3(player.transform.position.x + 1.8f, this.transform.position.y, this.transform.position.z);
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), "Score :" + score);


		GUI.Label(new Rect(40, 35, 100, 20), "X" +mouvement.chance);
	}

}
