using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public static string[] level1Section = new string[3] {"L1_S1", "L1_S2", "L1_S3"};
	//public string[] level1Section = new string[9] {"L1_S1", "L1_S2", "L1_S3", "L1_S4", "L1_S5", "L1_S6", "L1_S7", "L1_S8", "L1_S9"};
	public static int random;
	public static int maxArray;
	public string texte;
	public GUIStyle styleTitle;
	public GUIStyle styleBtn;
	Vector2 pos;
	Color couleur;
	bool depart = false;


	void Start () {
		couleur.r = 0;
		couleur.g = 0;
		couleur.b = 0;
		couleur.a = 0;
		styleTitle.normal.textColor = couleur;
		Invoke ("dragon", 1);
	}

	void dragon(){
		depart = true;
	}

	void Update () {
		if (!depart)
			return;
		couleur = styleTitle.normal.textColor;
		if(couleur.a < 1)
			couleur.a += 0.5f * Time.deltaTime;
		styleTitle.normal.textColor = couleur;
	}
	
	void OnGUI() {
		pos.x = GUILayoutUtility.GetRect (new GUIContent (texte), "label").width;
		pos.y = GUILayoutUtility.GetRect (new GUIContent (texte), "label").height;

		int hs = PlayerPrefs.GetInt ("HighScore");

		GUI.Label (new Rect ((Screen.width/2)-(pos.x/2), 0, pos.x, pos.y), hs.ToString());
		GUI.Label (new Rect ((Screen.width/2)-(pos.x/2), 20, pos.x, pos.y), PlayerPrefs.GetInt("Score").ToString());
		
		GUI.Label (new Rect ((Screen.width/2)-(pos.x/2), (Screen.height/5)-(pos.y/2), pos.x, pos.y), texte, styleTitle);

		//this.boutonJouer (550, 250, 200, 50, "Jouer");

		if (GUI.Button (new Rect (550, 250, 200, 50), "Jouer", styleBtn)) {
			PlayerPrefs.SetInt ("Score", 0);
			maxArray = level1Section.Length;
			random = Random.Range(0, maxArray);
			//random = Random.Range(0, 9);
			Application.LoadLevel(level1Section[random]);
			mouvement.chance = 3;
		}
	}
}