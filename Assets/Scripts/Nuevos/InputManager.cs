using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance; 
    public InputManager GetInstance()
    {
        if(Instance == null)
        {
            Instance = FindObjectOfType<InputManager>();
            return Instance;
        }
        return Instance;
    }


    CamionInput inputPJ1 = new CamionInput();
    CamionInput inputPJ2 = new CamionInput();

    public CamionInput GetInputPJ1()
    {
        return inputPJ1;
    }
    public CamionInput GetInputPJ2()
    {
        return inputPJ2;
    }

}
public class CamionInput
{

    public enum Buttons
    {
        Start,
        Left,
        Right,
        Down
    }

    string ButtonToString(Buttons button)
    {
        switch (button)
        {
            case Buttons.Start:
                return "Start1";
                break;
            case Buttons.Left:
                return "Left";
                break;
            case Buttons.Right:
                return "Right";
                break;
            case Buttons.Down:
                return "Down";
                break;
            default:
                return "";
                break;
        }
    }

    public bool GetButton(Buttons button)
    {
        string btnStr = ButtonToString(button);
        return Input.GetButton(btnStr);
    }

    public float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }
}
