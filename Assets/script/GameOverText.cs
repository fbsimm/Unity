using UnityEngine;
using System.Collections;

public class GameOverText : MonoBehaviour{
	
	public string texte;
	public GUIStyle style;
	Vector2 pos;
	Color couleur;
	bool depart = false;
	bool bouton  = false;
	//Rect labelRect;

	// Use this for initialization
	void Start () {
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

		pos.x = GUILayoutUtility.GetRect (new GUIContent (texte), "label").width;
		pos.y = GUILayoutUtility.GetRect (new GUIContent (texte), "label").height;

		GUI.Label (new Rect ((Screen.width/2)-(pos.x/2), (Screen.height/3)-(pos.y/2), pos.x, pos.y), texte, style);

		if(bouton){
			PlayerPrefs.Save();
			Menu.boutonJouer((Screen.width/2)-(pos.x/2), (Screen.height/2)-(pos.y/2), pos.x, pos.y, "Rejouer");
		}
	}
}
