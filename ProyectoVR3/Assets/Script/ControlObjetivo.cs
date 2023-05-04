using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjetivo : MonoBehaviour
{
    public float velocidad;

    public float posMax,posMin;

    public static ControlObjetivo instance;

    private Vector3 posicionObj,posicionObjMax,posicionObjMin;
    private bool movimientoHaciaFin;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        posicionObj = transform.position;

        posicionObjMax = new Vector3(posicionObj.x, posicionObj.y, posMax);
        posicionObjMin = new Vector3(posicionObj.x, posicionObj.y, posMin);


    }
    private void Update()
    {
        Mover();

    }
    void Mover()
    {
        Vector3 posicionDestino = (movimientoHaciaFin) ? posicionObjMax : posicionObjMin;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        if (transform.position.z == posicionObjMax.z)
        {
            movimientoHaciaFin = false;

        }

        if (transform.position.z == posicionObjMin.z)
        {

            movimientoHaciaFin = true;

        }
    }

    public IEnumerator Acierto(GameObject g)
    {
        yield return new WaitForSeconds(0.3f);
        g.GetComponent<Animation>().Play("ObjetivoDisparoAbajo");
        StartCoroutine(Levantar(g));
    }

    IEnumerator Levantar(GameObject g)
    {

        yield return new WaitForSeconds(3f);
        g.GetComponent<Animation>().Play("ObjetivoDisparoArriba");

    }

}
