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

    private GameObject objEscena;
    void Start()
    {
        isPressed = false;
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

        Destroy(GameObject.FindGameObjectWithTag("ObjetoUsable"));

        Instantiate(obj, new Vector3(-0.956f,1.25f,-0.78f), Quaternion.Euler(0,180,-90));

    }
}
