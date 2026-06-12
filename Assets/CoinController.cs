using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public CircleCollider2D Collider2D;
    public PersonagemController  personagemController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            personagemController.AddToPoints(1);
            Destroy(this.gameObject);
            
        }
    }

}
