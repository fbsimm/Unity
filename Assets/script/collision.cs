using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {
	public float chance = 3f;
	private bool mort = false;
	float timer;
	// Use this for initialization
	void Start () {
		timer = Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(0, 0, 0);
		if(mort)
			timer += Time.deltaTime;
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ennemi") {

			if(!mort){
				chance--;
				mort = true;
				print ("Vous ete mort, il vous reste " + chance + " vie");
			}
			if(timer >= 3){
				transform.position = new Vector3(-4.729806f,transform.position.y, transform.position.z);
				mort = false;
				timer = Time.deltaTime;
			}
		}
		
	}
}
