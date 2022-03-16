using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    private SFXManager sfxManager;
    private BGMMananger bgmManager;
    public int contadorMonedas;
    public Text coinsText;
    public int killsGoomba;
    public Text goombaText;
    
    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMMananger>();
    }

    public void DeathMario()
    {
        sfxManager.DeathSound();
        bgmManager.StopBGM();
        SceneManager.LoadScene("EndMenu");
    }

    public void VictoriaMario()
    {
        sfxManager.CogerBandera();
        bgmManager.StopBGM();
        SceneManager.LoadScene("EndMenu");

    }

    //Funcion para matar al Goomba
    public void DeadGoomba(GameObject goomba) 
    {
        //Variable para el animator,script y colliuder del goomba
        Animator goombaAnimator;
        Enemy goombaScript;
        BoxCollider2D goombaCollider;
        //Assignamos las variable
        goombaScript = goomba.GetComponent<Enemy>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        goombaAnimator.SetBool("GoombaMuerte", true);
        
        goombaScript.isAlive = false;

        //goombaCollider.size = new Vector2(1, 0.5f);
        //goombaCollider.offset = new Vector2(0, 0.25f);

        goombaCollider.enabled = false;

        Destroy(goomba, 0.3f);
        
        killsGoomba = killsGoomba+1;
        Debug.Log("Has asesinado un total de "+killsGoomba+" Goomba/s");
        goombaText.text = "DeadGoombas: " + killsGoomba;

        sfxManager.GoombaSound();

    }
    public void CuentaKillGoomba(GameObject kills)
    {
        
        Debug.Log("Has asesinado un total de "+killsGoomba+" Goomba/s");
        goombaText.text = "DeadGoombas: " + killsGoomba;
    }

    public void ColeccionarMoneda (GameObject moneda)
    {
        Animator monedaAnimator;
        BoxCollider2D monedaCollider;

        monedaAnimator = moneda.GetComponent<Animator>();
        monedaCollider = moneda.GetComponent<BoxCollider2D>();
        Destroy(moneda);
         contadorMonedas = contadorMonedas+1;
        Debug.Log("Tienes un total de "+contadorMonedas+" monedas");
        
        coinsText.text = "Coins: " + contadorMonedas;
        
        sfxManager.CogerMoneda();

    }
    public void BanderaVictoria (GameObject bandera)
    {
        BoxCollider2D banderaCollider;

        banderaCollider = bandera.GetComponent<BoxCollider2D>();

        sfxManager.CogerBandera();


    }


}
