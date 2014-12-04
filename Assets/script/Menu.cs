using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public static string[] level1Section = new string[3] {"L1_S1", "L1_S2", "L1_S3"};
	//public string[] level1Section = new string[9] {"L1_S1", "L1_S2", "L1_S3", "L1_S4", "L1_S5", "L1_S6", "L1_S7", "L1_S8", "L1_S9"};
	public static int random;
	public static int maxArray;

	public Menu(){

	}

	void OnGUI() {
		this.boutonJouer (550, 250, 200, 50, "Jouer");
	}

	public static void boutonJouer(float posX, float posY, float width, float height, string value){
		if (GUI.Button (new Rect (posX, posY, width, height), value)) {
			PlayerPrefs.SetInt ("Score", 0);
			maxArray = level1Section.Length;
			random = Random.Range(0, maxArray);
			//random = Random.Range(0, 9);
			Application.LoadLevel(level1Section[random]);
			mouvement.chance = 3;
		}
	}
}