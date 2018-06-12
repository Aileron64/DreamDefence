using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour 
{

	float speed = -0.2f;

	void Update () 
	{		
		transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

		if (transform.position.x <= -15)
			transform.position = new Vector3(15, transform.position.y, 0);
	}
}
