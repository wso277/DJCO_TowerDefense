using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour
{

    public int currentLifePoints;
    public int totalLifePoints = 3;

    // Use this for initialization
    void Start()
    {
        currentLifePoints = totalLifePoints;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int amount)
    {
        currentLifePoints -= amount;

        if (currentLifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
