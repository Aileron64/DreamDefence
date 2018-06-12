using UnityEngine;
using System.Collections;

public class AnimalBehaviour : MonoBehaviour {
	
	public int health;
	const int MAX_HEALTH = 500; //this is the most amount of health any animal can have.
	public int animalID;
	float animalVelocityX = -1.5f;
	const int amountOfAnimals = 3;
	//ANIMAL IDS ARE AS FOLLOWS
	// 0 - Squirrel
	// 1 - Badger
	// 2 - Orc
	GameObject boxBase;
	public Transform poof;

	// Use this for initialization
	void Start(){
		boxBase = GameObject.Find("Base");
	}

	// Update is called once per frame
	void Update(){
		transform.Translate(animalVelocityX * Time.deltaTime, 0.0f, 0.0f);
		if (transform.position.x <= boxBase.transform.position.x + 3.5f){
			animalVelocityX = 0.0f;
		}
	}

	protected internal void AddHealth(int _health){
		if (_health > 0){ //Adding health
			health += _health;
			if (health > MAX_HEALTH){
				health -= (MAX_HEALTH - health);
			}
		}else if (_health < 0){ //Subtracting health
			health += _health;
			if (health <= 0){ //if animal has less than 0 health
				Destroy(); //destroy it
			}
		}
	}

	void Destroy(){
		GameObject clonePoof;
		clonePoof = Instantiate(poof,transform.position,transform.rotation) as GameObject;
		Destroy(gameObject);
	}
}