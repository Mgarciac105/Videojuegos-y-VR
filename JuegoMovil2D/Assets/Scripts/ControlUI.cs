using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlUI : MonoBehaviour
{
    public static ControlUI instance;

    private TextMeshProUGUI Tiempo;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    Tiempo = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void setTiempo(string t)
    {
        Tiempo.text = t;
    }
    public void setIntentos(int n)
    {
            transform.GetChild(n).gameObject.SetActive(false);
        
    }
}
