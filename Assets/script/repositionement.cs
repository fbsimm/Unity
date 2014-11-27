using UnityEngine;
using System.Collections;

public class repositionement : MonoBehaviour {
	public Vector3 metToilacalisse;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(mouvement.timer >= 3){

			if(transform.position.x >0){
				transform.position = new Vector3 (0, transform.position.y, transform.position.z);
			}
			
			else if(gameObject.CompareTag("Background_Ville1")){
				transform.position = new Vector3 (14, transform.position.y, transform.position.z);
			}
			
			else if(gameObject.CompareTag("Background_Ville2")){
				transform.position = new Vector3 (16, transform.position.y, transform.position.z);
			}
		}
	
	}
}
