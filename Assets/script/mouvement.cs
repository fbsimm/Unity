using UnityEngine;
using System.Collections;

public class mouvement : MonoBehaviour {

	public GameObject player;
	public float maxSpeed = 10f;
	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	private bool sliding;
	private bool punch;
	public static int chance = 3;
	private bool mort = false;
	private bool depart = true;

	Animator anim;

	// Var pour le temps
	double timer;
	double timer_punch;
	double timer_slide;
	double timer_debut;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();


		//Init pour le temps
		timer = 0;
		timer_punch = 0;
		timer_slide = 0;
		timer_debut = 0;
	}
	
	// Appelé a chaques frame dans 1 sec
	void Update (){
		BoxCollider2D box = collider2D as BoxCollider2D;

		if (depart) {
			timer_debut += Time.deltaTime;
			if(timer_debut >= 3){
				depart = false;
			}
		}
		if(timer >= 3){
			transform.position = new Vector3(-4.729806f,transform.position.y, transform.position.z);
			mort = false;
			anim.SetBool("Dead", false);
			timer = Time.deltaTime;
		}
		//Punch
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			if(!punch){
				CircleCollider2D circle = gameObject.AddComponent("CircleCollider2D") as CircleCollider2D;
				circle.radius = 0.12f;
				circle.center = new Vector2(0.36f, 0.12f);
				circle.isTrigger = true;
			}
			anim.SetBool("Punch", true);
			punch = true;
			timer_punch = 0;
		}
		//Saut
		if(grounded && Input.GetKeyDown(KeyCode.UpArrow)){
			anim.SetBool("grounded", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		//Slide
		if(grounded && Input.GetKeyDown(KeyCode.DownArrow)){
			anim.SetBool("sliding", true);
			box.size = new Vector2 (0.97f, 0.55f);
			box.center = new Vector2 (0, -0.17f);
			sliding = true;
			timer_slide = 0;
		}
		//Trucs pour le temps
		//Compteur pour le respawn
		if(mort && !sliding && !punch)
			timer += Time.deltaTime;
		//Compteur pour le punch
		if(punch){
			timer_punch += Time.deltaTime;
			if(timer_punch >= 1){
				punch = false;
				anim.SetBool("Punch", false);
				timer_punch = 0;
				Destroy(GetComponent<CircleCollider2D>());
			}
			if(grounded && Input.GetKeyDown(KeyCode.UpArrow)){
				punch = false;
				anim.SetBool("Punch", false);
				timer_punch = 0;
			}
		}
		//Compteur pour le slide
		if(sliding){
			timer_slide += Time.deltaTime;
			if(timer_slide >= 1){
				anim.SetBool("sliding", false);
				box.size = new Vector2 (0.66f, 0.9f);
				box.center = new Vector2 (0, 0);
				sliding = false;
				timer_slide = 0;
			}
			if(grounded && Input.GetKeyDown(KeyCode.UpArrow)){
				sliding = false;
				anim.SetBool("sliding", false);
				timer_slide = 0;
			}
		}
	}
	/*Appelé a tout les 1/60 frame dans 1 sec*/
	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
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
		}

	}

	/*Aussitot que le joueur est en collision avec un Ennemi*/
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ennemi") {
			if(!mort){
				chance--;
				mort = true;
				print ("Vous ete 2 mort, il vous reste " + chance + " vie");
				anim.SetBool("Dead", true);
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Ennemi") {
			Destroy(coll.gameObject);
			GUICamera.score += 50;
		}
		if (coll.gameObject.tag == "Objet") {
			GUICamera.score += 100;
			Destroy(coll.gameObject);
		}
	}

}
