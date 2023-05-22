using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControlUI : MonoBehaviour
{
    TextMeshProUGUI puntuacion;
    TextMeshProUGUI tiempo;
    public static ControlUI instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        puntuacion = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tiempo = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
    }
    
    public void SetTiempo (string t)
    {

        tiempo.text = t;

    }

    public void SetPuntuacion(string p)
    {
        puntuacion.text= p;
    }
}
