using UnityEngine;
using System.Collections;

public class ctrl_Touch : MonoBehaviour {

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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		BoxCollider2D box = collider2D as BoxCollider2D;

		if () {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			anim.ResetTrigger("Run");
			anim.SetTrigger("sliding");
			box.size = new Vector2 (0.97f, 0.55f);
			box.center = new Vector2 (0, -0.17f);
			sliding = true;
			timer_slide = 0;
		}
	}
}
