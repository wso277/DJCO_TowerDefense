using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tower : MonoBehaviour {

	/*health of player*/
	public int MaxHealth = 100;
	public GameObject OuchEffect; // quando o jogador recebe "damage"

	public int Health{ get; private set; }
	public bool IsDead { get; private set; }

	
	public void Awake(){
		/*health of player*/
		Health = MaxHealth;
	}
	
	public void Update(){

	}
}
























