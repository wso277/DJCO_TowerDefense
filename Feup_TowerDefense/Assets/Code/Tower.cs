using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tower : MonoBehaviour {

	/*health of player*/
	public int MaxHealth = 100;
	public GameObject OuchEffect; // quando o jogador recebe "damage"
	private Vector2 _direction;
	private Vector2 _velocity;
	public float fireRate = 100;
	public float range = 4;

	public int Health{ get; private set; }
	public bool IsDead { get; private set; }

	
	public void Awake(){
		/*health of player*/
		Health = MaxHealth;
		this.GetComponent<CircleCollider2D> ().radius = range;
	}
	
	public void Update(){
	}
}