using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvas : MonoBehaviour
{
    Canvas canvasCamera;
    [SerializeField] Camera cameraConduccion;
    [SerializeField] Camera cameraDescarga;
    [SerializeField] Player camionPlayer;
    [SerializeField] GameObject volanteCamion;

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
                canvasCamera.worldCamera = cameraDescarga;

                break;
            case Player.Estados.EnConduccion:
                
                volanteCamion.SetActive(true);
                canvasCamera.worldCamera = cameraConduccion;

                break;
            case Player.Estados.EnCalibracion:
                break;
            case Player.Estados.EnTutorial:
                break;
        }
    }
}
