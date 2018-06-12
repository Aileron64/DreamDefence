using UnityEngine;
using System.Collections;

public enum ProjectileState {Held, Released}

public class ProjectileMotion : MonoBehaviour {

	protected internal Vector2 shootDirection; //the direction the projectile will start shooting at. We will plug in the arrow shooting script to this later.
	protected internal Vector2 shootVelocity; //the velocity of the projectile
	Vector2 shootAcceleration; //the acceleration of the projectile
	float gravityForce = -9.81f; //gravity of the projectile. Set to Earth's gravity as default
	protected internal ProjectileState state = ProjectileState.Released;

	// Use this for initialization
	void Start(){
		shootDirection = new Vector2(0,0); //set direction to 0 initially
		shootVelocity = new Vector2(shootDirection.x, shootDirection.y); //set velocity coords to shoot direction
		shootAcceleration = new Vector2(0.0f,gravityForce); //set acceleration to 0 in x direction and gravity in y direction
	}

	// Update is called once per frame
	void Update(){
		if (state == ProjectileState.Released){
			shootVelocity.x += (shootAcceleration.x * Time.deltaTime);
			shootVelocity.y += (shootAcceleration.y * Time.deltaTime);
			transform.Translate(shootVelocity.x * Time.deltaTime, (shootVelocity.y * Time.deltaTime), 0.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "animal"){
        	collision.gameObject.GetComponent<AnimalBehaviour>().AddHealth(-10);
        	Destroy(gameObject);
	    }else if (collision.gameObject.tag == "projectile"){
	    	Destroy(collision.gameObject);
	    	Destroy(gameObject);
	    }
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}