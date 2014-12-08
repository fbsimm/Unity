using UnityEngine;
using System.Collections;

public class GameOverText : MonoBehaviour{
	
	public string texte;
	public GUIStyle style;
	Vector2 pos;
	Color couleur;
	bool depart = false;
	bool bouton  = false;
	public GUIStyle styleBtn;
	//Rect labelRect;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore")){
			PlayerPrefs.SetInt ("HighScore", PlayerPrefs.GetInt("Score"));
		}
		couleur.r = 255;
		couleur.g = 255;
		couleur.b = 255;
		couleur.a = 0;
		style.normal.textColor = couleur;
		Invoke ("dragon", 1);
		Invoke ("boutonAffiche", 3);
	}
	
	// Update is called once per frame
	void Update () {
		if (!depart)
			return;
		couleur = style.normal.textColor;
		if(couleur.a < 1)
			couleur.a += 0.5f * Time.deltaTime;
		style.normal.textColor = couleur;
	}

	void dragon(){
		depart = true;

	}

	void boutonAffiche(){
		bouton = true;
	}

	void OnGUI(){

		int hs = PlayerPrefs.GetInt ("HighScore");
		
		GUI.Label (new Rect ((Screen.width/2)-(pos.x/2), 50, pos.x, pos.y), hs.ToString(), style);
		GUI.Label (new Rect ((Screen.width/2)-(pos.x/2), 110, pos.x, pos.y), PlayerPrefs.GetInt("Score").ToString(), style);

		pos.x = GUILayoutUtility.GetRect (new GUIContent (texte), "label").width;
		pos.y = GUILayoutUtility.GetRect (new GUIContent (texte), "label").height;

		GUI.Label (new Rect ((Screen.width/2)-(pos.x/2), (Screen.height/3)-(pos.y/2), pos.x, pos.y), texte, style);

		if(bouton){
			PlayerPrefs.Save();
			if (GUI.Button (new Rect ((Screen.width/2)-(pos.x/2), (Screen.height/2)-(pos.y/2), pos.x, pos.y), "Rejouer", styleBtn)) {
				PlayerPrefs.SetInt ("Score", 0);
				Menu.maxArray = Menu.level1Section.Length;
				int random = Random.Range(0, Menu.maxArray);
				//random = Random.Range(0, 9);
				Application.LoadLevel(Menu.level1Section[random]);
				mouvement.chance = 3;
			}
		}
	}
}	