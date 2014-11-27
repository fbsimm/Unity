using UnityEngine;
using System.Collections;

public class GameOverText : MonoBehaviour {

	private Vector2 pos;
	public string texte;
	Rect labelRect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		pos.x = Screen.width / 2f;
		pos.y = Screen.height / 1.8f;
		labelRect = GUILayoutUtility.GetRect (new GUIContent("Partie Terminée"), "label");

		GUI.Label(labelRect, "Partie Terminée");
	}
}
