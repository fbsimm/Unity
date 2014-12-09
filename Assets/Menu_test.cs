using UnityEngine;
using System.Collections;

public class Menu_test : MonoBehaviour {
	public Texture2D play, control, credit;
	public GUIStyle btnMenu, title, label;
	private Vector2 titleS, labelPlay, labelControl, labelCredit;
	public static string[] level1Section = new string[3] {"L1_S1", "L1_S2", "L1_S3"};
	//public string[] level1Section = new string[9] {"L1_S1", "L1_S2", "L1_S3", "L1_S4", "L1_S5", "L1_S6", "L1_S7", "L1_S8", "L1_S9"};
	public static int random, maxArray;
	


	// Use this for initialization
	void Start () {
		label.fontSize = Mathf.Min(Screen.height,Screen.width)/12;
		title.fontSize = Mathf.Min(Screen.height,Screen.width)/5;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){

		titleS.x = GUILayoutUtility.GetRect (new GUIContent ("Ner D. Boy"), "label").width;
		titleS.y = GUILayoutUtility.GetRect (new GUIContent ("Ner D. Boy"), "label").height;

		labelPlay.x = GUILayoutUtility.GetRect (new GUIContent ("Jouer"), "label").width;
		labelPlay.y = GUILayoutUtility.GetRect (new GUIContent ("Jouer"), "label").height;

		labelControl.x = GUILayoutUtility.GetRect (new GUIContent ("Controle"), "label").width;
		labelControl.y = GUILayoutUtility.GetRect (new GUIContent ("Controle"), "label").height;

		labelCredit.x = GUILayoutUtility.GetRect (new GUIContent ("Crédit"), "label").width;
		labelCredit.y = GUILayoutUtility.GetRect (new GUIContent ("Crédit"), "label").height;

		//Grand Titre
		GUI.Label(new Rect(Screen.width/2-titleS.x/2, Screen.height/6-titleS.y/2, titleS.x, titleS.y), "Ner D. Boy", title);

		//Label a coté des boutons
		GUI.Label(new Rect(Screen.width/1.85f-labelPlay.x/2, Screen.height*0.40f-labelPlay.y/2, labelPlay.x, labelPlay.y), "Jouer", label);
		GUI.Label(new Rect(Screen.width/1.85f-labelControl.x/2, Screen.height*0.625f-labelControl.y/2, labelControl.x, labelControl.y), "Controle", label);
		GUI.Label(new Rect(Screen.width/1.85f-labelCredit.x/2, Screen.height*0.85f-labelCredit.y/2, labelCredit.x, labelCredit.y), "Crédit", label);

		if(GUI.Button(new Rect(Screen.width*0.25f-play.width/2, Screen.height*0.40f-play.height/2, play.width, play.height), play, btnMenu)){
			PlayerPrefs.SetInt ("Score", 0);
			maxArray = level1Section.Length;
			random = Random.Range(0, maxArray);
			//random = Random.Range(0, 9);
			Application.LoadLevel(level1Section[random]);
			mouvement.chance = 3;
		}
		if(GUI.Button(new Rect(Screen.width*0.25f-control.width/2, Screen.height*0.625f-control.height/2, control.width, control.height), control, btnMenu)){
			Debug.Log("Control");
		}
		if(GUI.Button(new Rect(Screen.width*0.25f-credit.width/2, Screen.height*0.85f-credit.height/2, credit.width, credit.height), credit, btnMenu)){
			Debug.Log("Credit");
		}
	}
}
