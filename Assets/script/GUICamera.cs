using UnityEngine;
using System.Collections;

public class GUICamera : MonoBehaviour {
	public GameObject player;
	public static int score = 0;
	public Texture2D coeur;

	float virtualWidth = 600f;
	float virtualHeight = 400f;

	private Vector3 scale;
	

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

		scale.x = Screen.width / virtualWidth;
		scale.y = Screen.height / virtualHeight;
		scale.z = 1;

		Matrix4x4 svMat = GUI.matrix;

		GUI.matrix = Matrix4x4.Scale (scale);

		GUI.Label(new Rect(10, 10, 100, 20), "Score :" + score);


		GUI.Label(new Rect(40, 35, 100, 20), "X" +mouvement.chance);

		GUI.Label(new Rect(5, 15, coeur.width, coeur.height), coeur);

		GUI.matrix = svMat;
	}

}
