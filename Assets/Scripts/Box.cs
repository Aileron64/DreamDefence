using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour 
{
	SpriteRenderer spriteRenderer;

	int level = 1;

	public Sprite box2;
	public Sprite box3;
	public Sprite box4;	

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (KidBehaviour.currentLevel == 2 && level == 1)
		{
			spriteRenderer.sprite = box2;
			level = 2;
		}
		else if (KidBehaviour.currentLevel == 3 && level == 2)
		{
			spriteRenderer.sprite = box3;
			level = 3;
		}
		else if (KidBehaviour.currentLevel == 4 && level == 3)
		{
			spriteRenderer.sprite = box4;
			level = 4;
		}

	}


}
