using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class DeplacementAuto: MonoBehaviour
{
	public const float vitesse = 30f;
	
	private Transform voiture;
	private float periode;
	private Vector3 direction;
	
	
	void Start ()
	{
		this. voiture = transform;
		this. direction = Vector3. back;
	}
	
	
	void Update ()
	{
		this. periode = Time. deltaTime;
		this. voiture. position += this. direction * DeplacementAuto. vitesse * this. periode;
	}
}
