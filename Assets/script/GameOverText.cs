using UnityEngine;
using System.Collections;

public class GameOverText : MonoBehaviour{

	public string texte;
	public GUIStyle style, styleBtn, styleScore;

	private Vector2 titreS, labelS, labelHS, labelRejouer;
	private Color couleur;
	private bool depart, bouton = false;

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

		titreS.x = GUILayoutUtility.GetRect (new GUIContent (texte), "label").width;
		titreS.y = GUILayoutUtility.GetRect (new GUIContent (texte), "label").height;

		labelS.x = GUILayoutUtility.GetRect (new GUIContent ("Score : "+PlayerPrefs.GetInt("Score").ToString()), "label").width;
		labelS.y = GUILayoutUtility.GetRect (new GUIContent ("Score : "+PlayerPrefs.GetInt("Score").ToString()), "label").height;

		labelHS.x = GUILayoutUtility.GetRect (new GUIContent ("High Score : "+PlayerPrefs.GetInt("HighScore").ToString()), "label").width;
		labelHS.y = GUILayoutUtility.GetRect (new GUIContent ("High Score : "+PlayerPrefs.GetInt("HighScore").ToString()), "label").height;

		labelRejouer.x = GUILayoutUtility.GetRect (new GUIContent ("Rejouer?"), "button").width;
		labelRejouer.y = GUILayoutUtility.GetRect (new GUIContent ("Rejouer?"), "button").height;
	
		GUI.Label (new Rect ((Screen.width/2)-(titreS.x/2), (Screen.height/3)-(titreS.y/2), titreS.x, titreS.y), texte, style);
		GUI.Label (new Rect ((Screen.width/2)-(labelS.x/2), 110, labelS.x, labelS.y), "Score : "+PlayerPrefs.GetInt("Score").ToString(), styleScore);
		GUI.Label (new Rect ((Screen.width/2)-(labelHS.x/2), 50, labelHS.x, labelHS.y), "High Score : "+PlayerPrefs.GetInt("HighScore").ToString(), styleScore);
		
		if(bouton){
			PlayerPrefs.Save();
			if (GUI.Button (new Rect ((Screen.width/2)-(labelRejouer.x/2), (Screen.height/2)-(labelRejouer.y/2), labelRejouer.x, 70), "Rejouer?", styleBtn)) {
				PlayerPrefs.SetInt ("Score", 0);
				Menu.maxArray = Menu.level1Section.Length;
				int random = Random.Range(0, Menu.maxArray);
				//random = Random.Range(0, 9);
				mouvement.chance = 3;
				mouvement.depart = true;
				mouvement.mort = false;
				Application.LoadLevel(Menu.level1Section[random]);
			}
		}
	}
}	