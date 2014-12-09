using UnityEngine;
using System.Collections;

public class delaySpot : MonoBehaviour {

	bool ouvre = false;
	Light lumiere;


	// Use this for initialization
	void Start () {
		lumiere = GetComponent<Light>();
		lumiere.intensity = 0;
		Invoke ("Allume", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (ouvre && lumiere.intensity <= 2.5f)
			lumiere.intensity += 1f * Time.deltaTime;
	}

	void Allume(){
		ouvre = true;
	}
}
