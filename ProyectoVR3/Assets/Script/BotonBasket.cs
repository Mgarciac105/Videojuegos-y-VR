using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BotonBasket : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    public GameObject obj;

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
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.025f, 0);
            onRelease.Invoke();
            isPressed = false;

        }
    }

    public void StartGame()
    {
        obj.transform.rotation = Quaternion.Euler(0, 90, 6f);
    }
}

