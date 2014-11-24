using UnityEngine;
using System.Collections;

public class repositionement : MonoBehaviour {
	public Vector3 metToilacalisse;

	// Use this for initialization
	void Start () {
		if (gameObject.CompareTag("Background_Ville1"))
			metToilacalisse = new Vector3 (0, transform.position.y, transform.position.z);
		/*else if (gameObject.CompareTag("Background_Ville2"))
			metToilacalisse = new Vector3 (14, transform.position.y, transform.position.z);
		else if (gameObject.CompareTag("Background_Ville3"))
			metToilacalisse = new Vector3 (0, transform.position.y, transform.position.z);
		else if (gameObject.CompareTag("Background_Ville4"))
			metToilacalisse = new Vector3 (16, transform.position.y, transform.position.z);*/
		else
			metToilacalisse = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		if(mouvement.timer >= 3){

			transform.position = metToilacalisse;
		}
	
	}
}
