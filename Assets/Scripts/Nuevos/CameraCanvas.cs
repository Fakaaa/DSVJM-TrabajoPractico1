using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvas : MonoBehaviour
{
    Canvas canvasCamera;
    [SerializeField] Camera cameraCalibracion;
    [SerializeField] Camera cameraConduccion;
    [SerializeField] Camera cameraDescarga;
    [SerializeField] Player camionPlayer;
    [SerializeField] GameObject volanteCamion;
    [SerializeField] GameObject inventoryCamion;
    [SerializeField] GameObject startButton1;
    [SerializeField] GameObject startButton2;

    void Start()
    {
        canvasCamera = GetComponent<Canvas>();
    }

    void Update()
    {
        switch (camionPlayer.EstAct)        
        {
            case Player.Estados.EnDescarga:

                volanteCamion.SetActive(false);
                inventoryCamion.SetActive(true);
                canvasCamera.worldCamera = cameraDescarga;

                DisableStartButtons();

                break;
            case Player.Estados.EnConduccion:
                
                volanteCamion.SetActive(true);
                inventoryCamion.SetActive(true);
                canvasCamera.worldCamera = cameraConduccion;

                DisableStartButtons();

                break;
            case Player.Estados.EnCalibracion:

                volanteCamion.SetActive(false);
                inventoryCamion.SetActive(false);
                canvasCamera.worldCamera = cameraCalibracion;

                EnableStartButtons();

                break;
            case Player.Estados.EnTutorial:
                break;
        }
    }

    void DisableStartButtons()
    {
        if (GameManager.Instancia != null)
        {
            switch (GameManager.Instancia.ModoActual)
            {
                case GameManager.ModoDeJuego.SinglePlayer:
                    startButton1.SetActive(false);
                    break;
                case GameManager.ModoDeJuego.LocalMultiplayer:
                    //startButton1.SetActive(false);
                    //startButton2.SetActive(false);
                    break;
            }
        }
    }

    void EnableStartButtons()
    {
        if (GameManager.Instancia != null)
        {
            switch (GameManager.Instancia.ModoActual)
            {
                case GameManager.ModoDeJuego.SinglePlayer:
                    startButton1.SetActive(true);
                    break;
                case GameManager.ModoDeJuego.LocalMultiplayer:
                    //startButton1.SetActive(true);
                    //startButton2.SetActive(true);
                    break;
            }
        }
    }
}
