using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instrukcja : MonoBehaviour
{
    public void ZmienScene()
    {
        SceneManager.LoadScene(3);
    }
}
