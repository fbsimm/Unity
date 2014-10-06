using UnityEngine;
using System.Collections;

public class nextSection : MonoBehaviour {
	//Tableau contenant toutes les differentes scenes des niveaux
	public string[] level1Section = new string[9] {"L1_S1", "L1_S2", "L1_S3", "L1_S4", "L1_S5", "L1_S6", "L1_S7", "L1_S8", "L1_S9"};
	public string[] level2Section = new string[9] {"L2_S1", "L2_S2", "L2_S3", "L2_S4", "L2_S5", "L2_S6", "L2_S7", "L2_S8", "L2_S9"};
	public string[] level3Section = new string[9] {"L3_S1", "L3_S2", "L3_S3", "L3_S4", "L3_S5", "L3_S6", "L3_S7", "L3_S8", "L3_S9"};
	public string[] level4Section = new string[9] {"L4_S1", "L4_S2", "L4_S3", "L4_S4", "L4_S5", "L4_S6", "L4_S7", "L4_S8", "L4_S9"};
	public string[] level5Section = new string[9] {"L5_S1", "L5_S2", "L5_S3", "L5_S4", "L5_S5", "L5_S6", "L5_S7", "L5_S8", "L5_S9"};

	private int level;
	private int random;

	void OnTriggerEnter2D(Collider2D other) {
		//On va chercher le nom de la derniere scene chargee
		string currentScene = Application.loadedLevelName;
		//Avec son nom on determine a quel niveau on est
		switch(currentScene){
		case "L1_S1":
		case "L1_S2":
		case "L1_S3":
		case "L1_S4":
		case "L1_S5":
		case "L1_S6":
		case "L1_S7":
		case "L1_S8":
		case "L1_S9":	//On refait un random pour chargee une differente scene du meme niveau
						do{
							random = Random.Range(0, 3);
							//random = Random.Range(0, 9);
						}while(currentScene == level1Section[random]);
			       		Application.LoadLevel(level1Section[random]);
						print (level1Section[random]);
						break;

		case "L2_S1":
		case "L2_S2":
		case "L2_S3":
		case "L2_S4":
		case "L2_S5":
		case "L2_S6":
		case "L2_S7":
		case "L2_S8":
		case "L2_S9":	do{
							random = Random.Range(0, 3);
							//random = Random.Range(0, 9);
						}while(currentScene == level2Section[random]);
						Application.LoadLevel(level2Section[random]);
						print (level2Section[random]);
						break;

		case "L3_S1":
		case "L3_S2":
		case "L3_S3":
		case "L3_S4":
		case "L3_S5":
		case "L3_S6":
		case "L3_S7":
		case "L3_S8":
		case "L3_S9":	do{
							random = Random.Range(0, 3);
							//random = Random.Range(0, 9);
						}while(currentScene == level3Section[random]);
						Application.LoadLevel(level3Section[random]);
						print (level3Section[random]);
						break;

		case "L4_S1":
		case "L4_S2":
		case "L4_S3":
		case "L4_S4":
		case "L4_S5":
		case "L4_S6":
		case "L4_S7":
		case "L4_S8":
		case "L4_S9":	do{
							random = Random.Range(0, 3);
							//random = Random.Range(0, 9);
						}while(currentScene == level4Section[random]);
						Application.LoadLevel(level4Section[random]);
						print (level4Section[random]);
						break;

		case "L5_S1":
		case "L5_S2":
		case "L5_S3":
		case "L5_S4":
		case "L5_S5":
		case "L5_S6":
		case "L5_S7":
		case "L5_S8":
		case "L5_S9":	do{
							random = Random.Range(0, 3);
							//random = Random.Range(0, 9);
						}while(currentScene == level5Section[random]);
						Application.LoadLevel(level5Section[random]);
						print (level5Section[random]);
						break;
		}
	}
}