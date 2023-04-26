using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControlClickable : MonoBehaviour
{
    public int x, y;
    public TextMeshProUGUI text;


    private void OnMouseDown()
    {
        if (this.gameObject.CompareTag("Bomba"))
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;

            Time.timeScale = 0.0f;
        }
        else if(this.gameObject.CompareTag("Vacio")) text.text = Generador.instance.getCellsAround(x,y).ToString();

    }

}
