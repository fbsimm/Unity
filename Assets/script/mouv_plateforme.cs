using UnityEngine;
using System.Collections;

public class mouv_plateforme : MonoBehaviour {

	private Vector2 pos;
	private bool monter = false;
	private float vitesse = 0.01f;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		pos = this.transform.position;

		if(!monter)
			pos.y -= vitesse;
		else
			pos.y += vitesse;
		if(pos.y <= 1.3f){
			monter = true;
			vitesse = 0.001f;
		}
		if(pos.y >= 1.35f)
			monter = false;

		this.transform.position = pos;
	}
}
