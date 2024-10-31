using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class CycleVie: MonoBehaviour
{
	private GameObject voiture;
	private CoffreVoiture coffre;
	
	
	// En désactivant la voiture, ces affichages n'ont pas lieu.
	// Je ne peux pas mettre d'argument dans les fonctions Awake et Start.
	
	void Awake ()
	{
		Debug. Log ("La voiture se réveille.");
		this. voiture = gameObject;
	}
	
    void Start ()
    {
		Debug. Log ("La voiture finit son paramétrage juste avant utilisation.");
		this. coffre = new CoffreVoiture ();
    }
	
	
    void Update ()
    {
		if (Input. GetKey (KeyCode. D))
		{
			this. voiture. SetActive (false);
			Destroy (this);
		}
    }
	
	
	void OnDestroy ()
	{
		Debug. Log ("La voiture est en voie de destruction.");
	}
}
