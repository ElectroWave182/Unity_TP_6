using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class GestionVoiture
{
	private double essence;
	
	
	public GestionVoiture ()
	{
		this. essence = 1000;
		Debug.Log ("Essence : " + this. essence);
	}
	
	public double getEssence ()
	{
		return this. essence;
	}
	
	public void setEssence (double valeur)
	{
		this. essence = valeur;
	}
	
	public bool roule (double consommation)
	{
		this. essence -= consommation;
		return this. essence > 0;
	}
}
