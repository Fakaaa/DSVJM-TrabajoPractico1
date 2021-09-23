using UnityEngine;

public class InputButtonsPallets : MonoBehaviour
{
    public PalletMover palletMover;

    public void ActiveFirstStepPalletDeploy()
    {
        palletMover.PrimerPaso();
    }

    public void ActiveSecondStepPalletDeploy()
    {
        palletMover.SegundoPaso();
    }

    public void ActiveThirdStepPalletDeploy()
    {
        palletMover.TercerPaso();
    }
}
