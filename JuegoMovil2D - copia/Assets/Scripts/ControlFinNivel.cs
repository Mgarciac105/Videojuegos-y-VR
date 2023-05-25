using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlFinNivel : MonoBehaviour
{
    public Canvas canvas;

    private TextMeshProUGUI numPuntuacionNivel, numPuntuacionTotal;

    private int puntuacionNivel,puntuacionTotal;
    // Start is called before the first frame update
    void Start()
    {


        numPuntuacionNivel = canvas.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
        numPuntuacionTotal = canvas.transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>();

        puntuacionNivel = ControlDatosJuego.instance.GetPuntuacionNivel();
        puntuacionTotal = ControlDatosJuego.instance.GetPuntuacionTotal();


        numPuntuacionNivel.text = puntuacionNivel.ToString("0000");
        numPuntuacionTotal.text = puntuacionTotal.ToString("0000");

    }

}
