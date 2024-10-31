using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Deplacement: MonoBehaviour
{
	public float vitesse;
	
	private Transform voiture;
	private Transform [] roues;
	private int angleRoues = 0;
	private const int maxAngleRoues = 30;
	private GestionVoiture gestion;
	private float periode;
	private Vector3 direction;
	private Vector3 angleRotation;
	
	
	void Start ()
	{
		this. voiture = transform;
		this. roues = new Transform []
		{
			this. voiture. Find ("Wheel_fl"),
			this. voiture. Find ("Wheel_fr"),
			this. voiture. Find ("Wheel_rl"),
			this. voiture. Find ("Wheel_rr")
		};
		this. gestion = new GestionVoiture ();
	}
	
	
	void Update ()
	{
		this. periode = Time. deltaTime;
		this. controle ();
		if (this. gestion. roule (this. vitesse * this. periode / 2))
		{
			Vector3 distance = this. direction * this. vitesse * this. periode;
			this. voiture. Translate (distance, this. voiture);
			this. voiture. Rotate (angleRotation);
			this. rouler (2 * Regard. degres (distance));
		}
	}
	
	private void controle ()
	{
		// Détection des entrées
		this. direction = Vector3. zero;
		this. angleRotation = Vector3. zero;
		bool z = Input. GetKey (KeyCode. UpArrow);
		bool q = Input. GetKey (KeyCode. LeftArrow);
		bool s = Input. GetKey (KeyCode. DownArrow);
		bool d = Input. GetKey (KeyCode. RightArrow);
		
		// La voiture avance
		if (z)
		{
			Regard. deplace = true;
			this. direction += Vector3. forward;
		}
		
		// La voiture recule
		if (s)
		{
			Regard. deplace = true;
			this. direction += Vector3. back / 2;
		}
		
		// Les roues tournent à gauche
		if (q && !d && this. angleRoues != -Deplacement. maxAngleRoues)
		{
			this. angleRoues = -Deplacement. maxAngleRoues;
			this. tournerRoues (this. angleRoues);
		}
		
		// Les roues tournent à droite
		if (!q && d && this. angleRoues != Deplacement. maxAngleRoues)
		{
			this. angleRoues = Deplacement. maxAngleRoues;
			this. tournerRoues (this. angleRoues);
		}
		
		// Les roues sont stables
		if ((q && d || !q && !d) && this. angleRoues != 0)
		{
			this. tournerRoues (-this. angleRoues);
			this. angleRoues = 0;
		}
		
		// La voiture tourne à gauche
		if (z && q  && !d
		|| !z && !q && s && d)
		{
			this. angleRotation += new Vector3 (0, -this. vitesse * this. periode, 0);
		}
		
		// La voiture tourne à droite
		if (z && !q && d
		|| !z && q  && s && !d)
		{
			this. angleRotation += new Vector3 (0, this. vitesse * this. periode, 0);
		}
	}
	
	private void rouler (Vector3 distanceAngulaire)
	{
		foreach (Transform roue in this. roues)
		{
			roue. Rotate (distanceAngulaire, Space. Self);
		}
	}
	
	private void tournerRoues (int angle)
	{
		this. roues [0]. Rotate (0, angle, 0, Space. World);
		this. roues [1]. Rotate (0, angle, 0, Space. World);
	}
}
