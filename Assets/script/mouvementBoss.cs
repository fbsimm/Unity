using UnityEngine;
using System.Collections;

public class mouvementBoss : MonoBehaviour {

	//Variable généraux.
	public GameObject Boss;
	public GameObject Chenille;
	public GameObject Plateforme;
	public GameObject Lumiere;
	public float maxSpeed = 0.05f;
	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	private bool laser;
	private bool coupBras;
	private bool coupPoing;
	private bool missiles;
	public static int vie = 3;
	public static bool mort = false;
	public static bool playerMort = false;
	public static bool depart = true;
	private int random;
	public float cptAtt = 0;
	public float cptCollMissile = 0;
	public static bool openChest = false;

	//Variable pour pas écrire "Animator" à chaque fois, parce que nous les programmeurs on est vache.
	Animator anim;

	// Var pour le temps.
	public static
	double timer_debut;
	double timer_laser;
	double timer_coupBras;
	double timer_coupPoing;
	double timer_missiles;
	double timer_playerMort;

	// Initialiser les trucs.
	void Start () {
		anim = GetComponent<Animator>();

		//Init pour le temps.
		timer_laser = 0;
		timer_coupBras = 0;
		timer_coupPoing = 0;
		timer_missiles = 0;
		timer_playerMort = 0
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
				print("Départ");
			}
		}

		//Quand le personnage meurt, le timer de sa meurt se lance
		if(playerMort)
			timer_playerMort += Time.deltaTime;
		//Quand le personnage meurt, 3 sec avant de retourner au début.
		if(timer_playerMort >= 3){
			transform.position = new Vector3(-4.729806f,transform.position.y, transform.position.z);
			playerMort = false;
			depart = true;
			timer_playerMort = 0;
			timer_debut = 0;
			anim.Play("idleBoss");
		}

		if(!depart && !mort && !laser && !coupBras && !coupPoing && !missiles && !openChest && !playerMort){
			random = Random.Range(1, 10);
			switch(random){
			case 1:	//laser
				cptAtt++;
				//laser = true;
				break;

			case 2: //coupBras
				cptAtt++;
				coupBras = true;
				if(timer_coupBras >= 3f){
					coupBras = false;
					timer_coupBras = 0;
					anim.SetTrigger("idleBoss");
				}
				else{
					timer_coupBras += Time.deltaTime;
				}
				break;

			case 3: //coupPoing
				cptAtt++;
				//coupPoing = true;
				break;
			}
			print(cptAtt);
			if(vie == 3 && cptAtt >= 3){
				//missiles
				missiles = true;
				cptAtt = 0;
				print("reste2vies");
			}

			if(vie == 2 && cptAtt >= 4){
				//missiles
				missiles = true;
				cptAtt = 0;
				print("reste1vies");
			}

			if(vie == 1 && cptAtt >= 5){
				//missiles
				missiles = true;
				cptAtt = 0;
				print("reste0vies");
			}
			depart = false;
		}
	}
	void FixedUpdate(){
		if(!depart && !mort){
			this.transform.Translate (Vector3.right * maxSpeed);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Missile") {
			if(!mort && missiles && !openChest){
				cptCollMissile++;
				if((vie == 3 && cptCollMissile == 1) || (vie == 2 && cptCollMissile == 2) || (vie == 1 && cptCollMissile == 3)){
					cptCollMissile = 0;
					missiles = false;
					//play anim openChest for a couple secs
					openChest = true;
				}
			}
		}
		if (coll.gameObject.tag == "Player") {
			if(!depart && !mort && !laser && !coupBras && !coupPoing && !playerMort && !missiles && openChest){
				vie--;
				openChest = false;
				if(vie == 0){
					mort = true;
				}
			}
			if(laser || coupBras || coupPoing){
				playerMort = true;
			}
		}
	}
}
