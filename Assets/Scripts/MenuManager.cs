using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLVL1()
    {
        SceneManager.LoadScene("Nivel1MarcF");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
