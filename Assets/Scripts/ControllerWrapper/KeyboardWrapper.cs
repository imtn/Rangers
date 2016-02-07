using UnityEngine;
using System.Collections;
using System;

public class KeyboardWrapper : ControllerInputWrapper {

	public KeyboardWrapper(int joyNum) : base(joyNum)
    {
		
    }

    public override float GetAxis(Axis axis, bool isRaw = false)
    {
        string axisName = "";
        float scale = 1;
        Vector3 vec = Vector3.zero;
        switch (axis)
        {
            case Axis.LeftStickX:
                axisName = getAxisName("Horizontal", "Horizontal", "Horizontal");
                break;
            case Axis.LeftStickY:
                axisName = getAxisName("Vertical", "Vertical", "Vertical");
                break;
            case Axis.RightStickX:
                vec = retrieveMouseOffset();
                vec -= Vector3.up * vec.y;
                return vec.normalized.x;
            case Axis.RightStickY:
                vec = retrieveMouseOffset();
                vec -= Vector3.up * vec.y;
                return vec.normalized.z;
			case Axis.DPadX:
				axisName = getAxisName("DPadX", "DPadX", "DPadX");
				scale = 0.09f;
				break;
			case Axis.DPadY:
				axisName = getAxisName("DPadY", "DPadY", "DPadY");
				scale = 0.09f;
				break;
        }
        return Input.GetAxis(axisName) * scale;
    }

    Vector3 retrieveMouseOffset()
    {
//        if (currentPlayer == null || mainCamera == null)
//        {
//            return Vector3.zero;
//        }
//        Ray checkRay = mainCamera.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;
//        if (Physics.Raycast(checkRay, out hit, 100))
//        {
//            //Debug.Log(hit.collider.name);
//            return hit.point - currentPlayer.position;
//        }
//
//        //Debug.DrawLine(checkRay.origin, checkRay.origin + checkRay.direction * 100);
//        
//        return (checkRay.origin + checkRay.direction * 100) - currentPlayer.position;
		return Vector3.zero;
    }

    public override float GetTrigger(Triggers trigger, bool isRaw = false)
    {

        string triggerName = "";
        switch (trigger)
        {
            case Triggers.RightTrigger:
				triggerName = getButtonName("RightTrigger", "RightTrigger", "RightTrigger");
                break;
            case Triggers.LeftTrigger:
				triggerName = getButtonName("LeftTrigger", "LeftTrigger", "LeftTrigger");
                break;
        }

        if (Input.GetButton(triggerName))
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }

    public override bool GetButton(Buttons button, bool isDown = false)
    {
        string buttonName = "";
        switch (button)
        {
            case Buttons.RightBumper:
                buttonName = getButtonName("RB", "RB", "RB");
                break;
            case Buttons.LeftBumper:
                buttonName = getButtonName("LB", "LB", "LB");
                break;
            case Buttons.A:
                buttonName = getButtonName("A", "A", "A");
                break;
			case Buttons.B:
				buttonName = getButtonName("B", "B", "B");
				break;
			case Buttons.X:
				buttonName = getButtonName("X", "X", "X");
				break;
			case Buttons.Y:
				buttonName = getButtonName("Y", "Y", "Y");
				break;
            case Buttons.Start:
                buttonName = getButtonName("Start", "Start", "Start");
                break;
			case Buttons.LeftStickClick:
				buttonName = getButtonName("LeftStickClick", "LeftStickClick", "LeftStickClick");
				break;
			case Buttons.RightStickClick:
				buttonName = getButtonName("RightStickClick", "RightStickClick", "RightStickClick");
				break;
        }
        if (isDown)
        {
            return Input.GetButtonDown(buttonName);
        }
        return Input.GetButton(buttonName);
    }

    public override bool GetButtonUp(Buttons button)
    {
        throw new NotImplementedException();
    }

    protected override string getAxisName(string winID, string linID, string osxID)
    {
        string axisName = "k" + "_Axis_" + winID;


        return axisName;
    }

    protected override string getButtonName(string winID, string linID, string osxID)
    {
        string buttonName = "k" + "_Button_" + winID;
        return buttonName;
    }

	public override string GetButtonHelper (Buttons button)
	{
		throw new NotImplementedException ();
	}
}
