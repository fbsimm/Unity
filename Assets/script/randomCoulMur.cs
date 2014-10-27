using UnityEngine;
using System.Collections;

public class randomCoulMur : MonoBehaviour {

	public Sprite[] arrayMur = new Sprite[] {};
	private int random;
	private int maxArray;
	SpriteRenderer spit;

	void Start(){
		maxArray = arrayMur.Length;
		random = Random.Range(0, maxArray);
		this.GetComponent<SpriteRenderer>().sprite = arrayMur[random];
	}
}
