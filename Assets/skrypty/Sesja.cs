using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Sesja : MonoBehaviour
{
    [SerializeField] Text zyciaText;
    [SerializeField] Text wynikText;
    [SerializeField] Text topWynikText;
    [SerializeField] int zyciaStartowe;

    int liczbaZyc;
    int wynik;
    int topWynik;

    private void Awake()
    {
        int instancjaLicznik = FindObjectsOfType<Sesja>().Length;
        if (instancjaLicznik > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        liczbaZyc = zyciaStartowe;
        topWynik = PlayerPrefs.GetInt("topWynik");
    }
    private void Update()
    {
        var pilki = GameObject.FindGameObjectsWithTag("piłka");

        if (pilki.Length == 0)
        {
            OdejmijZycia();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Kontroloer>().ResetPiłki();
        }

        var cegly = GameObject.FindGameObjectsWithTag("cegła");

        if(cegly.Length == 0)
        {
            Time.timeScale = 0f;
            UstawTopWynik();
            SceneManager.LoadScene(6);
            Debug.Log("Wygrana");
        }

        zyciaText.text = liczbaZyc.ToString();
        wynikText.text = wynik.ToString();
        topWynikText.text = topWynik.ToString();
    }

    public void PodniesWynik(int value)
    {
        wynik += value;
    }
    public void OdejmijZycia()
    {
        liczbaZyc--;
        if(liczbaZyc<=0)
        {
            Debug.Log(liczbaZyc);
            UstawTopWynik();
            Time.timeScale= 0f;
            Destroy(gameObject);
            SceneManager.LoadScene(6);
        }
    }
    private void UstawTopWynik()
    {
        if (wynik > topWynik)
        {
            topWynik = wynik;
            PlayerPrefs.SetInt("topWynik", topWynik);
        }
    }
}
