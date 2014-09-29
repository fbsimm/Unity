using UnityEngine;
using System.Collections;

public class mouvementBackground : MonoBehaviour {
	
	private bool mouvement = false;
	public float speed = 1f;
	
	// Var pour le temps
	double timer;

	// Use this for initialization
	void Start () {
		//Init pour le temps
		timer = 0;
	}
	
	// Appelé a chaques frame dans 1 sec
	void Update (){
		timer += Time.deltaTime;
		if(timer >= 3) {
			mouvement = true;
		}
	}
	// Update is called once per frame
	void LateUpdate () {
		if(mouvement) {
			this.transform.Translate (Vector3.right * Time.deltaTime);
		}
	}
}