using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Regard: MonoBehaviour
{
	
	public GameObject objetCible;
	public static bool deplace = false;
	
	private Transform cible;
	private Transform camera;
	private static readonly Vector3 positionInitiale = new Vector3 (0, 10, 5);
	private Vector3 positionPrecedente;
	private const float vitesse = 1.5f;
	private const double rayon = 30;
	private float
		angle,
		periode
	;
	
	void Start ()
	{
		this. cible = this. objetCible. GetComponent <Transform> ();
		this. camera = transform;
		this. positionPrecedente = this. cible. position;
		this. camera. position = this. cible. position + Regard. positionInitiale + new Vector3 (Convert. ToSingle (Regard. rayon), 0, 0);
		this. angle = 0;
	}
	
	void Update ()
	{
		if (Regard. deplace && this. angle >= -Math. PI / 2)
		{
			this. periode = Time. deltaTime * Regard. vitesse;
			this. angle -= periode;
			this. camera. Rotate (0, Regard. degres (periode), 0);
			
			float x = Convert. ToSingle (Regard. rayon * Math. Cos (angle));
			float z = Convert. ToSingle (Regard. rayon * Math. Sin (angle));
			this. camera. position = this. cible. position + Regard. positionInitiale + new Vector3 (x, 0, z);
		}
		
		else if (Regard. deplace)
		{
			this. camera. position +=  this. cible. position - this. positionPrecedente;
		}
		this. positionPrecedente = this. cible. position;
	}
	
	public static float degres (float radians)
	{
		return radians * 180 / Convert. ToSingle (Math. PI);
	}
	public static Vector3 degres (Vector3 radians)
	{
		return radians * 180 / Convert. ToSingle (Math. PI);
	}
}
