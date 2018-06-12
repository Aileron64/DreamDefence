using UnityEngine;
using System.Collections;

public class OrdBeha : MonoBehaviour 
{
	Animation ani;

	void Awake(){
		ani = transform.Find("OrcAxe").gameObject.animation;
		Debug.Log(ani);
	}

	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x <= 0){
			if (animation != null){
				animation.Stop();
				animation.Play("axeSwingAni");
			}
		}
	}
}
