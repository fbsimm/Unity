using UnityEngine;
using System.Collections;

public class nextSection : MonoBehaviour {
	public string[] level1Section = new string[9] {"L1_S1", "L1_S2", "L1_S3", "L1_S4", "L1_S5", "L1_S6", "L1_S7", "L1_S8", "L1_S9"};
	public string[] level2Section = new string[9] {"L2_S1", "L2_S2", "L2_S3", "L2_S4", "L2_S5", "L2_S6", "L2_S7", "L2_S8", "L2_S9"};
	public string[] level3Section = new string[9] {"L3_S1", "L3_S2", "L3_S3", "L3_S4", "L3_S5", "L3_S6", "L3_S7", "L3_S8", "L3_S9"};
	public string[] level4Section = new string[9] {"L4_S1", "L4_S2", "L4_S3", "L4_S4", "L4_S5", "L4_S6", "L4_S7", "L4_S8", "L4_S9"};
	public string[] level5Section = new string[9] {"L5_S1", "L5_S2", "L5_S3", "L5_S4", "L5_S5", "L5_S6", "L5_S7", "L5_S8", "L5_S9"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		string currentScene = Application.loadedLevelName;
		switch(currentScene){
		case "L1_S1":
		case "L1_S2":
		case "L1_S3":
		case "L1_S4":
		case "L1_S5":
		case "L1_S6":
		case "L1_S7":
		case "L1_S8":
		case "L1_S9":	print ("level1");
						break;

		case "L2_S1":
		case "L2_S2":
		case "L2_S3":
		case "L2_S4":
		case "L2_S5":
		case "L2_S6":
		case "L2_S7":
		case "L2_S8":
		case "L2_S9":	
						break;

		case "L3_S1":
		case "L3_S2":
		case "L3_S3":
		case "L3_S4":
		case "L3_S5":
		case "L3_S6":
		case "L3_S7":
		case "L3_S8":
		case "L3_S9":	
						break;

		case "L4_S1":
		case "L4_S2":
		case "L4_S3":
		case "L4_S4":
		case "L4_S5":
		case "L4_S6":
		case "L4_S7":
		case "L4_S8":
		case "L4_S9":	
						break;

		case "L5_S1":
		case "L5_S2":
		case "L5_S3":
		case "L5_S4":
		case "L5_S5":
		case "L5_S6":
		case "L5_S7":
		case "L5_S8":
		case "L5_S9":	
						break;
		}
	}
}


//EditorApplication.currentScene