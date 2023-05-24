using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    public GameObject obj;
    public GameObject[] objEscena;
    
    private List<Vector3> posicionInicial=new List<Vector3>();
    private List<Quaternion> rotacionInicial = new List<Quaternion>();
    private List<Objetos> lista = new List<Objetos>();
    public Vector3[] test;

    void Start()
    {
        isPressed = false;

        Debug.Log("Cuenta"+objEscena.Length);

        //posicionInicial = objEscena.transform.position;
        //rotacionInicial = objEscena.transform.rotation;

        for (int i = 0; i < objEscena.Length; i++)
        {
            Debug.Log("objeto " + objEscena[i]+" "+i);

            var miObjeto = new Objetos();
            miObjeto.Index = i;
            miObjeto.Transform = objEscena[i].transform.position;
            miObjeto.Rotation = objEscena[i].transform.rotation;
            lista.Add(miObjeto);
        }


    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.01f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.025f, 0);
            onRelease.Invoke();
            isPressed = false;

        }
    }

    public void RespawnObj()
    {

        if (GameObject.Find("Pistola"))
        {
            Destroy(GameObject.Find("Pistola"));
        }else if(GameObject.FindGameObjectsWithTag("Balon") != null)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Balon"))
            {
                Destroy(go);
            }
        }

        //Instantiate(obj, posicionInicial, rotacionInicial);

        lista.ForEach(item =>
        {
            Instantiate(obj, item.Transform, item.Rotation);
        });



    }
}

public class Objetos
{
    public int Index;
    public Vector3 Transform;
    public Quaternion Rotation;
}
