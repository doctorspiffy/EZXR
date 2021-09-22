/*
EZXR - a simple utility library for accessing Unity XR controller inputs
Version 9/27/2020

(C) 2020 9/21/2020 - Jason Leigh (leighj@hawaii.edu) - Laboratory for Advanced Visualization & Applications, University of Hawaii at Manoa
lava.hawaii.edu


To use it, just place it in your Asset folder and make calls in any of your scripts like:

if (EZXR.isLeftTriggerPressed()){print ("YIPPEE");}

Vector2 pad = EZXR.leftTouchPadTouched();

Functions:

TRIGGER BUTTONS
    bool isLeftTriggerPressed() - returns true when trigger is held down
    bool isLeftTriggerClicked() - only returns true the instant the trigger is pressed
    bool isLeftTriggerReleased() - only returns true if the trigger was pressed and released

    bool isRightTriggerPressed()
    bool isRightTriggerClicked()
    bool isRightTriggerReleased()

GRIP BUTTONS
    bool isLeftGripPressed()
    bool isLeftGripClicked()
    bool isLeftGripReleased()

    bool isRightGripPressed()
    bool isRightGripClicked()
    bool isRightGripReleased()

PRIMARY and SECONDARY BUTTONS
    bool isLeftPrimaryButtonTouched() - [X or A key on Oculus]
    bool isLeftPrimaryButtonPressed()
    bool isLeftPrimaryButtonClicked()
    bool isLeftPrimaryButtonReleased()

    bool isRightPrimaryButtonTouched() - [X or A key on Oculus]
    bool isRightPrimaryButtonPressed()
    bool isRightPrimaryButtonClicked()
    bool isRightPrimaryButtonReleased()

    bool isLeftSecondaryButtonTouched() - [Y or B key on Oculus]
    bool isLeftSecondaryButtonPressed()
    bool isLeftSecondaryButtonClicked()
    bool isLeftSecondaryButtonReleased()

    bool isRightSecondaryButtonTouched() - [Y or B key on Oculus]
    bool isRightSecondaryButtonPressed()
    bool isRightSecondaryButtonClicked()
    bool isRightSecondaryButtonReleased()

MENU BUTTONS
    bool isLeftMenuButtonPressed()
    bool isLeftMenuButtonClicked()
    bool isLeftMenuButtonReleased()

    bool isRightMenuButtonPressed()
    bool isRightMenuButtonClicked()
    bool isRightMenuButtonReleased()

TOUCHPADS
    Vector2 leftTouchPadTouched() - returns a Vector2 with X and Y location of where you touched (values ranger from -1 to 1)
    Vector2 rightTouchPadTouched()

    bool isLeftTouchPadPressed()
    bool isLeftTouchPadClicked()
    bool isLeftTouchPadReleased()

    bool isRightTouchPadPressed()
    bool isRightTouchPadClicked()
    bool isRightTouchPadReleased()

JOYSTICKS Windows Media
    Vector2 leftSecondary2DAxis()
    Vector2 rightSecondary2DAxis()

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EZXR
{
    enum HAND {LEFT,RIGHT};
    static bool leftTriggerAlreadyPressed=false;
    static bool rightTriggerAlreadyPressed=false;
    static bool leftMenuAlreadyPressed=false;
    static bool rightMenuAlreadyPressed=false;
    static bool leftTouchPadAlreadyPressed = false;
    static bool rightTouchPadAlreadyPressed = false;
    static bool leftGripAlreadyPressed = false;
    static bool rightGripAlreadyPressed = false;
    static bool leftPrimaryButtonAlreadyPressed = false;
    static bool rightPrimaryButtonAlreadyPressed = false;
    static bool leftSecondaryButtonAlreadyPressed = false;
    static bool rightSecondaryButtonAlreadyPressed = false;

public static bool isLeftTriggerPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }
public static bool isLeftTriggerClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftTriggerAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)){
                        leftTriggerAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                        leftTriggerAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isLeftTriggerReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftTriggerAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)){
                        leftTriggerAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                        leftTriggerAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }
public static bool isLeftGripPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
        return false;
    }

public static bool isLeftGripClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftGripAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue)){
                        leftGripAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue) {
                        leftGripAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

public static bool isLeftGripReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftTriggerAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue)){
                        leftTriggerAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue) {
                        leftTriggerAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }

public static bool isRightTriggerPressed(){
        var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
                return false;
    }

public static bool isRightTriggerClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightTriggerAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)){
                        rightTriggerAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                        rightTriggerAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isRightTriggerReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightTriggerAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)){
                        rightTriggerAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                        rightTriggerAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }
public static bool isRightGripPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;

            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
        return false;
    }

public static bool isRightGripClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightGripAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue)){
                        rightGripAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue) {
                        rightGripAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

public static bool isRightGripReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightTriggerAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue)){
                        rightTriggerAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue) {
                        rightTriggerAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }

public static bool isLeftMenuButtonPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
        return false;
    }
public static bool isLeftMenuButtonClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftMenuAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue)){
                        leftMenuAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue) {
                        leftMenuAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isLeftMenuButtonReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftMenuAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue)){
                        leftMenuAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue) {
                        leftMenuAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }
public static bool isRightMenuButtonPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers){
        
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue){
                return true;
            }
        }
        return false;
    }
public static bool isRightMenuButtonClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightMenuAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue)){
                        rightMenuAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue) {
                        rightMenuAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isRightMenuButtonReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightMenuAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue)){
                        rightMenuAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out triggerValue) && triggerValue) {
                        rightMenuAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }


    public static bool isLeftPrimaryButtonPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }

    public static bool isLeftPrimaryButtonTouched(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryTouch, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }
public static bool isLeftPrimaryButtonClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftPrimaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)){
                        leftPrimaryButtonAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue) {
                        leftPrimaryButtonAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isLeftPrimaryButtonReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftPrimaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)){
                        leftPrimaryButtonAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue) {
                        leftPrimaryButtonAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }

public static bool isLeftSecondaryButtonPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }

    public static bool isLeftSecondaryButtonTouched(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryTouch, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }
public static bool isLeftSecondaryButtonClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftSecondaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)){
                        leftSecondaryButtonAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue) {
                        leftSecondaryButtonAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isLeftSecondaryButtonReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftSecondaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)){
                        leftSecondaryButtonAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue) {
                        leftSecondaryButtonAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }
    public static bool isRightPrimaryButtonTouched(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryTouch, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }
  public static bool isRightPrimaryButtonPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }
public static bool isRightPrimaryButtonClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightPrimaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)){
                        rightPrimaryButtonAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue) {
                        rightPrimaryButtonAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isRightPrimaryButtonReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightPrimaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)){
                        rightPrimaryButtonAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue) {
                        rightPrimaryButtonAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }

public static bool isRightSecondaryButtonPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }

    public static bool isRightSecondaryButtonTouched(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
                bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryTouch, out triggerValue) && triggerValue)
            {
                return true;
            }
        }
             return false;
    }
public static bool isRightSecondaryButtonClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightSecondaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)){
                        rightSecondaryButtonAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue) {
                        rightSecondaryButtonAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isRightSecondaryButtonReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightSecondaryButtonAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)){
                        rightSecondaryButtonAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue) {
                        rightSecondaryButtonAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }
public static Vector2 leftTouchPadTouched(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        Vector2 triggerValue = new Vector2();
        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out triggerValue) && triggerValue != Vector2.zero){
                return triggerValue;
            }
        }
        return triggerValue;
    }

public static Vector2 leftSecondary2DAxis(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);
        Vector2 triggerValue = new Vector2();
        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondary2DAxis, out triggerValue) && triggerValue != Vector2.zero){
                return triggerValue;
            }
        }
        return triggerValue;
}

public static Vector2 rightSecondary2DAxis(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);
        Vector2 triggerValue = new Vector2();
        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondary2DAxis, out triggerValue) && triggerValue != Vector2.zero){
                return triggerValue;
            }
        }
        return triggerValue;
}
public static Vector2 rightTouchPadTouched(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        Vector2 triggerValue = new Vector2();
        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));

            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out triggerValue) && triggerValue != Vector2.zero){
                return triggerValue;
            }
        }
        return triggerValue;
    }

public static bool isLeftTouchPadPressed(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        bool triggerValue = false;
        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue){
                return triggerValue;
            }
        }
        return triggerValue;
    }

public static bool isLeftTouchPadClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftTouchPadAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue)){
                        leftTouchPadAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue) {
                        leftTouchPadAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isLeftTouchPadReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.LEFT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (leftTouchPadAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue)){
                        leftTouchPadAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue) {
                        leftTouchPadAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }

public static bool isRightTouchPadPressed(){

    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        bool triggerValue = false;;
        foreach (var device in handedControllers)
        {
            // Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));

            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue){
                return triggerValue;
            }
        }
        return triggerValue;
    }

public static bool isRightTouchPadClicked(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightTouchPadAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue)){
                        rightTouchPadAlreadyPressed = false;
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue) {
                        rightTouchPadAlreadyPressed=true;
                        return true;
                    }
                }
        }
        return false;
    }

    public static bool isRightTouchPadReleased(){
    var handedControllers = getHandedControllers(EZXR.HAND.RIGHT);

        foreach (var device in handedControllers)
        {
                bool triggerValue;
                if (rightTouchPadAlreadyPressed) {
                    if (!(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue)){
                        rightTouchPadAlreadyPressed = false;
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue) {
                        rightTouchPadAlreadyPressed=true;
                        return false;
                    }
                }
        }
        return false;
    }

static List<UnityEngine.XR.InputDevice> getHandedControllers(EZXR.HAND hand){
        List<UnityEngine.XR.InputDevice> handedControllers = new List<UnityEngine.XR.InputDevice>(); 

        if (hand==EZXR.HAND.RIGHT){
            var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
            UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, handedControllers);
        } else {
            var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
            UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, handedControllers);
        }
        return handedControllers;
    }

}