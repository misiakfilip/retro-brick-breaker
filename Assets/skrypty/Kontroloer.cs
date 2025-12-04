using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontroloer : MonoBehaviour
{
    [SerializeField] float predkosc = 30f;
    [SerializeField] Vector2 kierunek = new Vector2(1,4);
    [SerializeField] GameObject piłkaPrefab;

    Rigidbody2D rb2D;
    Vector3 piłkaOfset;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        piłka piłka = GetComponentInChildren<piłka>();
        piłkaOfset = piłka.transform.position - transform.position;
    }
    void Update()
    {
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * predkosc, 0);

        if (transform.childCount > 0 && Input.GetButtonDown("Jump"))
        {
            piłka piłka = GetComponentInChildren<piłka>();
            piłka.strzal(kierunek);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ResetPiłki();
        }
    }

    public void ResetPiłki()
    {
        piłka piłka = Instantiate(piłkaPrefab).GetComponent<piłka>();
        piłka.transform.parent= transform;
        piłka.transform.position = transform.position + piłkaOfset;
    }
}
