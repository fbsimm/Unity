using UnityEngine;
using System.Collections;

public class mouvement : MonoBehaviour {

	//Variable généraux.
	public GameObject player;
	public float maxSpeed = 10f;
	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public static bool sliding;
	private bool punch;
	public static int chance = 3;
	public static bool mort = false;
	public static bool depart = true;
	public static bool collisionBureau = false;

	//Sprite pour les ennemies
	public Sprite targetSprite;

	//Variable pour pas écrire "Animator" à chaque fois, parce que nous les programmeurs on est vache.
	Animator anim;

	// Var pour le temps.
	public static double timer;
	double timer_punch;
	double timer_slide;
	double timer_debut;
	double timer_score;
	double timer_mort;

	// Initialiser les trucs.
	void Start () {
		anim = GetComponent<Animator>();

		//Init pour le temps.
		timer = 0;
		timer_punch = 0;
		timer_slide = 0;
		timer_debut = 0;
		timer_score = 0;
		timer_mort = 0;
	}
	
	// Appelé a chaques frame que l'appareil génère.
	void Update (){
		//Variable pour pas écrire ça à chaque fois, parce que nous les programmeurs on est vache, encore. 
		BoxCollider2D box = collider2D as BoxCollider2D;

		//Au départ du jeu, 3 sec de temps mort.
		if (depart) {
			timer_debut += Time.deltaTime;
			if(timer_debut >= 3){
				depart = false;
			}
		}

		//Quand le personnage meurt, 3 sec avant de retourner au début.
		if(timer >= 3){
			transform.position = new Vector3(-4.729806f,transform.position.y, transform.position.z);
			mort = false;
			depart = true;
			timer = 0;
			timer_debut = 0;
			anim.Play("Idle");
		}

		if (!mort && !depart) {
			timer_score +=Time.deltaTime;
			if(timer_score >= 1 && GUICamera.score > 0){
					GUICamera.score -= 1;
					timer_score = 0;
					}
				}
		if(!mort && !punch && !sliding && !depart){
			//Punch
			if(grounded && gameObject.rigidbody2D.velocity.y <= 0){
				BoxCollider2D boite = gameObject.GetComponent("BoxCollider2D") as BoxCollider2D;
				boite.enabled = true;
				PolygonCollider2D poly = gameObject.GetComponent("PolygonCollider2D") as PolygonCollider2D;
				poly.enabled = false;
			}

			if(grounded && Input.GetButtonDown("Punch") && !sliding){
				if(!punch){
					CircleCollider2D circle = gameObject.AddComponent("CircleCollider2D") as CircleCollider2D;
					circle.radius = 0.12f;
					circle.center = new Vector2(0.36f, 0.12f);
					circle.isTrigger = true;
				}
				anim.ResetTrigger("Run");
				anim.SetTrigger("Punch");
				punch = true;
				timer_punch = 0;
			}

			//Saut
			if(grounded && Input.GetButtonDown("Jump") && !punch && !sliding){
				anim.ResetTrigger("Run");
				anim.SetTrigger ("Saut");
				BoxCollider2D boite = gameObject.GetComponent("BoxCollider2D") as BoxCollider2D;
				boite.enabled = false;
				PolygonCollider2D poly = gameObject.GetComponent("PolygonCollider2D") as PolygonCollider2D;
				poly.enabled = true;
				rigidbody2D.AddForce(new Vector2(0, jumpForce));
			}

			//Slide
			if(grounded && Input.GetButtonDown("Slide") && !punch){
				anim.ResetTrigger("Run");
				anim.SetTrigger("sliding");
				box.size = new Vector2 (0.97f, 0.55f);
				box.center = new Vector2 (0, -0.17f);
				sliding = true;
				timer_slide = 0;
			}
		}
		//Trucs pour le temps

		//Compteur pour le respawn
		if(mort){
			if(chance >= 0){
				timer += Time.deltaTime;
			}
			else
			{
				timer_mort += Time.deltaTime;
			}
		}
				

		//Compteur pour le punch
		if(punch){
			if(timer_punch >= 0.5f){
				punch = false;
				timer_punch = 0;
				Destroy(GetComponent<CircleCollider2D>());
				anim.SetTrigger("Run");
			}
			else{
				timer_punch += Time.deltaTime;
			}
		}

		//Compteur pour le slide
		if(sliding){
			if(timer_slide >= 1){
				sliding = false;
				timer_slide = 0;
				box.size = new Vector2 (0.66f, 0.9f);
				box.center = new Vector2 (0, 0);
				anim.SetTrigger("Run");
			}
			else{
				timer_slide += Time.deltaTime;
			}
		}
	}
	//Appelé a toutes les frames dans 1 sec.
	void FixedUpdate(){
		//C'est pour chercher la position du cercle qui vérifie si le joueur touche le sol.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		//On met à jour les variables du "Animator".
		anim.SetBool ("grounded", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		//Empecher le mouvement quand on est mort
		if(!depart){
			if (!mort) {
				if (!sliding)
					this.transform.Translate (Vector3.right * maxSpeed);
				else if (sliding)
					this.transform.Translate (Vector3.right * maxSpeed / 1.5f);
			}
			else{
				if(timer_mort >= 3){
					Application.LoadLevel("GameOver");
				}
			}
		}

	}

	//Aussitôt que le joueur est en collision avec un ennemi, on perd une vie.
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ennemi") {
			if(!mort){
				chance--;
				mort = true;
				anim.SetTrigger("Dead");
			}
		
		}
		if (coll.gameObject.tag == "Bureau") {
			collisionBureau = true;
		} 
	}
	

	//Si on frappe l'ennemie, on le détruit et on ajoute les points.
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Ennemi") {
			Destroy(coll.gameObject);
			GUICamera.score += 50;
		}
		if (coll.gameObject.tag == "Objet") {
			GUICamera.score += 100;
			Destroy(coll.gameObject);
		}
		if (coll.gameObject.tag == "Bureau"){
			collisionBureau = false;
		} 
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "Bureau") {
			if(timer_slide >= 0.9f){
				timer_slide = 0.9f;
			}
		}
	}
}
