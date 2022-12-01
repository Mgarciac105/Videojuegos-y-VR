using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ControlHUD : MonoBehaviour
{
    private TextMeshProUGUI textoNVidas;
    private TextMeshProUGUI textoNPowerUps;
    private TextMeshProUGUI textoTiempo;

    private void Awake()
    {
        textoNVidas = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textoNPowerUps = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textoTiempo = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {


    }



    public void setVidasHUD(string nVidas)
    {
        textoNVidas.text = "VIDAS: "+ nVidas;
    }

    public void setNPowerUps(string nPowerUps)
    {
        textoNPowerUps.text = "PowerUps "+ nPowerUps;
    }

    public void setTiempo(int Tiempo)
    {
        int minutos = Tiempo /60;
        int segundos = Tiempo%60;
        textoTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");

    }
}
