using UnityEngine;

public class InputButtonsCanvas : MonoBehaviour
{
    public PalletMover palletMoverDeploy;
    public PalletMover palletMoverCalibration;
    GameManager refGm;

    private void Start()
    {
        refGm = FindObjectOfType<GameManager>();
    }

    //-------------------------------------------------------------
    public void StartSinglePlayer()
    {
        refGm?.SetSinglePlayer();
    }
    public void StartPlayer1Multi()
    {
        refGm?.SetPlayer1Multi();
    }
    public void StartPlayer2Multi()
    {
        refGm?.SetPlayer2Multi();
    }
    //-------------------------------------------------------------
    //=============================================================
    //-------------------------------------------------------------
    public void FirstStepDeploy()
    {
        if (!palletMoverDeploy.Tenencia() && palletMoverDeploy.Desde.Tenencia())
            palletMoverDeploy.PrimerPaso();
    }

    public void FirstStepCalibration()
    {
        //if(!palletMoverCalibration.Tenencia() && palletMoverCalibration.Desde.Tenencia())
            palletMoverCalibration.PrimerPaso();
    }
    //-------------------------------------------------------------
    public void SecondStepDeploy()
    {
        if (palletMoverDeploy.Tenencia())
            palletMoverDeploy.SegundoPaso();
    }

    public void SecondStepCalibration()
    {
        //if (palletMoverCalibration.Tenencia())
            palletMoverCalibration.SegundoPaso();
    }

    //-------------------------------------------------------------
    public void ThirdStepDeploy()
    {
        if(palletMoverDeploy.segundoCompleto && palletMoverDeploy.Tenencia())
            palletMoverDeploy.TercerPaso();
    }

    public void ThirdStepCalibration()
    {
        //if(palletMoverCalibration.segundoCompleto && palletMoverCalibration.Tenencia())
            palletMoverCalibration.TercerPaso();
    }
    //-------------------------------------------------------------
}
