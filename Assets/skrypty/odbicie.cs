using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odbicie : MonoBehaviour
{
    BoxCollider2D bc2D;

    private void Awake()
    {
        bc2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "piłka")
        {
            // pozycja na belce (piłka.x - belka.x) / belka.width 
            float pozycja = (other.transform.position.x - transform.position.x) / bc2D.bounds.size.x;
            // zmiana velocity piłki zależna od pozycji
            other.rigidbody.velocity = new Vector2(pozycja, 1).normalized * other.rigidbody.velocity.magnitude;

        }

    }
}
