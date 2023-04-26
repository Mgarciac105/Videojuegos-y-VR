using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using TMPro;
public class ControlHUD : MonoBehaviour
{   
    [Header("Municion")]
    private TextMeshProUGUI textoRecarga;
    private TextMeshProUGUI textoMunicion;

    [Header("Vida")]
    private Slider sliderVida;
    private Image vidaColor;

    [Header("Stamina")]
    private Slider sliderStamina;

    [Header("Puntuacion")]
    private TextMeshProUGUI puntuacion;
    private TextMeshProUGUI puntuacionPausa;

    [Header("Ventanas")]
    public Transform ventanaPausa;
    private Transform ventanaFinJuego;

    [Header("Instance de este script")]
    public static ControlHUD instance;

    [Header("Tiempo")]
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoTiempoPausa;


    // Start is called before the first frame update
    void Awake()
    {

        instance = this;     

        textoRecarga = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        textoMunicion = transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();

        sliderVida = transform.GetChild(1).GetComponent<Slider>();
        vidaColor = transform.GetChild(1).GetChild(2).GetComponent<Image>();

        sliderStamina = transform.GetChild(2).GetComponent<Slider>();

        puntuacion = transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();

        ventanaPausa = transform.GetChild(4);
        puntuacionPausa = transform.GetChild(4).GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>();

        textoTiempo = transform.GetChild(5).GetComponent<TextMeshProUGUI>();

        textoTiempoPausa = transform.GetChild(4).GetChild(1).GetChild(4).GetComponent<TextMeshProUGUI>();


    }



    public void SetMunicionHUD(string municionActual, string municionMax)
    {
        textoMunicion.text = municionActual + "/" + municionMax;
    }

    public void SetVidaHUD(int vida, int vidaMax)
    {
        sliderVida.value = (float)vida/vidaMax;

        if(vida <= 60 && vida > 30)
        {
            vidaColor.color = new Color32(195, 192, 20, 255);
        }
        else if(vida <= 30){
            vidaColor.color = new Color32(195, 0, 14, 255);
        }
        else
        {
            vidaColor.color = new Color32(0, 195, 20, 255);
        }
    }

    public void SetStaminaHUD(float cantidad)
    {
        sliderStamina.value = cantidad / 100;
    }

    public void SetPuntuacionHUD(string str)
    {
        puntuacion.text = str;
        puntuacionPausa.text = str;
    }

    public void SetTiempoHUD(int tiempo)
    {
        int minutos = tiempo / 60;
        int segundos = tiempo % 60;
        textoTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");
        textoTiempoPausa.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
   
    public void CambiarEstadoVentanaPausa(bool pausa)
    {
        ventanaPausa.gameObject.SetActive(pausa);
        ventanaPausa.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Pausa";

    }
    public void EstablecerVentanaFinJuego(bool ganado)
    {

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        //ventanaFinJuego.SetActive(true);

        if (ganado)
        {
            
        }
        else
        {

        }

    }

}
