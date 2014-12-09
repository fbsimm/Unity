using UnityEngine;
using System.Collections;

public class GUICamera : MonoBehaviour {
	public GameObject player;
	public static int score = 0;
	public Texture2D coeur;
	public GUISkin style;
	public GUIStyle font;
	Color couleur;
	
	private float virtualWidth = 750f;
	private float virtualHeight = 500f;
	
	private Vector3 scale;
	
	
	// Use this for initialization
	void Awake() {
		//DontDestroyOnLoad(gameObject);
		score = PlayerPrefs.GetInt("Score");
	}
	
	void Start(){
		font.fontSize = Mathf.Min(Screen.height,Screen.width)/20;
		couleur.r = 255;
		couleur.g = 255;
		couleur.b = 255;
		couleur.a = 255;
		font.normal.textColor = couleur;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = new Vector3(player.transform.position.x + 1.8f, this.transform.position.y, this.transform.position.z);
	}
	
	void OnGUI() {
		
		//GUI.skin = style;
		
		//Grosseur de l'écran divisé par la grosseur souhaité
		scale.x = Screen.width / virtualWidth;
		scale.y = Screen.height / virtualHeight;
		scale.z = 1;
		
		Matrix4x4 svMat = GUI.matrix;
		
		//GUI.matrix = Matrix4x4.Scale (scale);
		
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height*0.2f), "");
		
		if(mouvement.chance >= 0)
			GUI.Label(new Rect(50, 45, 100, 20), "X " + mouvement.chance, font);
		else
			GUI.Label(new Rect(50, 45, 100, 20), "X " + 0, font);		
		
		GUI.matrix = svMat;
		
		GUI.Label(new Rect(10, 10, 100, 20), "Score : " + score, font);
		GUI.Label(new Rect(0, 25, coeur.width, coeur.height), coeur, font);
		
		//print(Time.realtimeSinceStartup);
	}
	
}
