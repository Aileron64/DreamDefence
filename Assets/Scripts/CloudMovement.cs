using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour 
{
	float speed = -0.2f;
	float originalCloudPositionY;

	void Start(){
		originalCloudPositionY = transform.position.y;
		transform.position = new Vector3(transform.position.x + Random.Range(-2,2), originalCloudPositionY + Random.Range(-2,2), transform.position.z);
	}

	void Update(){		
		transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
		if (transform.position.x <= -15)transform.position = new Vector3(15, originalCloudPositionY + Random.Range(-2,2), transform.position.z);
	}
}
