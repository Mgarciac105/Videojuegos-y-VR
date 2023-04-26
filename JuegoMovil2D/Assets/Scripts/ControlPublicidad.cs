using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class ControlPublicidad : MonoBehaviour,IUnityAdsShowListener
{

    public static ControlPublicidad Instance;
#if UNITY_IOS
[SerializeField] public string gameID="5226706";
#elif UNITY_ANDROID
[SerializeField] public string gameID= "5226707";
#elif UNITY_EDITOR
[SerializeField] public string gameID= "5226707";
#endif

    public string placementId = "PublicidadEntreNiveles";

    private void Awake()
    {
        Instance = this;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        ControlDatosJuego.instance.contadorEscenas++;
        ControlDatosJuego.instance.IniciarValores();

        SceneManager.LoadScene(ControlDatosJuego.instance.contadorEscenas);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        if (ControlDatosJuego.instance.contadorEscenas != SceneManager.GetActiveScene().buildIndex)
        {
            ControlDatosJuego.instance.contadorEscenas++;
            ControlDatosJuego.instance.IniciarValores();
            SceneManager.LoadScene(ControlDatosJuego.instance.contadorEscenas);
        }
        else SceneManager.LoadScene("Creditos");



    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Advertisement.Banner.SetPosition(BannerPosition.CENTER);
    }



    void Start()
    {

        Advertisement.Initialize(gameID, true);

    }

    public void MostrarPublicidad()
    {
        Advertisement.Show(placementId,this);
    }

}
