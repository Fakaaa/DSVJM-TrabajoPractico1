using UnityEngine;

//FACTORY PATTERN
public class CamionesInputManager : InputManager
{
    protected override InputCamion CreateInput(string player)
    {
        InputCamion input = null;

#if UNITY_EDITOR
        input = new CamionInputTouchKeys(player);
#elif UNITY_ANDROID
        input = new CamionInputTouch(player);
#else
        input = new CamionInputKeys(player);
#endif

        return input;
    }
}