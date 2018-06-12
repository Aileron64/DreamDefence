using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject projectile;
	Vector2 touchStartPosition;
	Vector2 touchMovePosition;
	Vector2 touchEndPosition;
	Vector2 touchStartWorldPos;
	Vector2 touchEndWorldPos;

	// Use this for initialization
	void Start(){
		GameObject cloneProjectile; //create a new projectile
		GameObject.Find("NumberTest").guiText.text = "ZERO";
	}

	// Update is called once per frame
	void Update(){
		if (Input.touchCount > 0){ //if there's a touch
			switch (Input.GetTouch(0).phase){ //get the touch phase
				case TouchPhase.Began:
					touchStartPosition = Input.GetTouch(0).position;
					touchStartWorldPos = Camera.main.ScreenToWorldPoint(touchStartPosition);
					break;
				case TouchPhase.Stationary:
					//will work on this later
					// touchMovePosition = Input.GetTouch(0).deltaPosition;
					// GameObject.Find("NumberTest").guiText.text = "(" + touchMovePosition.x + ", " + touchMovePosition.y + ")";
					break;
				case TouchPhase.Moved:

					break;
				case TouchPhase.Ended: //if user lifted finger
					touchEndPosition = Input.GetTouch(0).position; //grab the coordinates for the touch when finger is lifted
					Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touchEndPosition); //convert screen coordinates to world coordinates
    				touchEndWorldPos = new Vector2(worldPoint.x, worldPoint.y); //take the x and y position of these new world coordinates
					CreateProjectile(touchEndWorldPos - touchStartWorldPos);
					break;
			}
		}
		if (Input.GetButtonDown("Jump")){
			CreateProjectile(new Vector2(-4,-4));
		}
	}

	void CreateProjectile(Vector2 _direction){
		GameObject cloneProjectile; //create a new projectile
		cloneProjectile = Instantiate(projectile,transform.position,Quaternion.identity) as GameObject; //instantiate the projectile prefab on coords
		cloneProjectile.rigidbody2D.velocity = -(_direction);
	}
}