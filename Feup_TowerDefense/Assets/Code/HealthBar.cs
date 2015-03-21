using UnityEngine;
using System.Collections;
public class HealthBar : MonoBehaviour {
	public Tower Player;
	public Transform ForegroundSprite;
	public SpriteRenderer ForegroundRendered; // para trocar a cor da barra a medida que vai ate ao zero
	public Color MaxHelathColor = new Color (255 / 255f, 63 / 255f, 63 / 255f);
	public Color MinHealthColor = new Color (64 / 255f, 137 / 255f, 255 / 255f);
	
	public void Update(){
	/*	var healthPercent = Tower.Health / (float) Tower.MaxHealth;
		
		ForegroundSprite.localScale = new Vector3 (healthPercent, 1, 1);
		ForegroundRendered.color = Color.Lerp (MaxHelathColor, MinHealthColor, healthPercent);// retorna uma cor entre o max e min de acordo com a distancia
	*/}
}






