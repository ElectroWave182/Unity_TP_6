using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class CoffreVoiture
{
	private float capacite;
	
	//définition du constructeur par défaut
	public CoffreVoiture()
	{
		Debug.Log("Constructeur appelé");
		capacite = 0;
	}
	
	//définition du constructeur alternatif
	public CoffreVoiture(float capaciteCoffre)
	{
		capacite = capaciteCoffre;
		Debug.Log("Constructeur appelé avec : "+capaciteCoffre+" litres");
	}
	
	//définition du destructeur
	~CoffreVoiture()
	{
		Debug.Log("Destructeur appelé");
	}
}
