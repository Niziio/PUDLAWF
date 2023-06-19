using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour 
{
	private float dura, empieza;
	public float parallax;
	public GameObject camara;

	void Start () 
	{
		empieza = transform.position.x;
		dura = GetComponent<SpriteRenderer>().bounds.size.x;

	}
	
	void FixedUpdate () 
	{
		float temp = (camara.transform.position.x * (1 - parallax));
		float dist = (camara.transform.position.x * parallax);

		transform.position = new Vector3(empieza + dist, transform.position.y, transform.position.z);

		if (temp > empieza + dura)
			empieza += dura;
		else if (temp < empieza - dura) 
			empieza -= dura;

	}
}
