using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zdrowie : MonoBehaviour
{
    [SerializeField] int hp = 1;
    [SerializeField] int wynik = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "piłka")
        {
            hp--;
            if (hp <= 0)
            {
                FindObjectOfType<Sesja>().PodniesWynik(wynik);
                Destroy(gameObject);
            }
        }
    }

}
