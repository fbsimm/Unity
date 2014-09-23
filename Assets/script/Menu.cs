using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public string[] level1Section = new string[3] {"L1_S1", "L1_S2", "L1_S3"};
	//public string[] level1Section = new string[9] {"L1_S1", "L1_S2", "L1_S3", "L1_S4", "L1_S5", "L1_S6", "L1_S7", "L1_S8", "L1_S9"};

	void OnGUI() {
		if (GUI.Button (new Rect (550, 250, 200, 50), "Jouer")) {
			PlayerPrefs.SetInt ("Score", 0);
			int random = Random.Range(0, 3);
			//public int random = Random.Range(0, 9);
			Application.LoadLevel(level1Section[random]);
			//Application.LoadLevel ("Niveau1");
		}
	}
}