using UnityEngine;
using System.Collections;

/// Déplace l'ennemi
public class mouvEnnemi : MonoBehaviour {
	
	private float speed = 50f;

	// Update is called once per frame
	// Var pour le temps
	double timer_direction;
	
	// Use this for initialization
	void Start () {
		//Init pour le temps
		timer_direction = 0;
	}
	void Update () {
		timer_direction += Time.deltaTime;
		
				if (timer_direction >= 2) {
						speed = speed * -1;
						timer_direction = 0;
				}
		}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Sol")
			rigidbody2D.velocity = new Vector2(speed * Time.deltaTime, 100 * Time.deltaTime);

		
	}
	/*void FixedUpdate(){
		
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		if (coll.gameObject.tag == "Sol") {
			rigidbody2D.velocity = new Vector2(speed, 0);
				}

		}*/
	
	
}
