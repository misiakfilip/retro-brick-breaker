using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ustawienia : MonoBehaviour
{
    public void ZmienScene()
    {
        SceneManager.LoadScene(2);
    }
}
