using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class KidBehaviour : MonoBehaviour {
	
	public int health;
	const int MAX_HEALTH = 100;
	GUITexture healthBar;
	public Texture2D[] healthBarArr = new Texture2D[10];
	int experience;
	readonly int[] MAX_EXPERIENCE = {500, 2000};

	// Use this for initialization
	void Start(){
		healthBar = GameObject.Find("HealthBar").guiTexture;
		Debug.Log(animation);
	}

	// Update is called once per frame
	void Update(){
		healthBar.guiTexture.texture = healthBarArr[(health / 10) - 1];
	}

	protected internal void AddHealth(int _health){
		if (_health > 0){ //Adding health
			health += _health;
			if (health > MAX_HEALTH){
				health -= (MAX_HEALTH - health);
			}
		}else if (_health < 0){ //Subtracting health
			health += _health;
			if (health <= 0){ //if player has less than 0 health
				//GAME OVER
			}
		}
	}

	protected internal void AddExperience(int _experience){
		if (_experience > 0){ //adding experience
			experience += _experience;
			for (int i = 0; i < MAX_EXPERIENCE.Length; i++){
				if (experience >= MAX_EXPERIENCE[i]){
					//next level
				}
			}
		}
	}
}