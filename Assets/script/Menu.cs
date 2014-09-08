using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public Texture btnTexture;

	void OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button (new Rect (550, 250, 200, 50), "Jouer")) {
			PlayerPrefs.SetInt ("Score", 0);
			Application.LoadLevel ("Niveau1");
		}
	}
}
