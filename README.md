# EZXR
Old school VR library for UnityXR

This is a Unity C# script to let you access UnityXR controller inputs by just using function calls rather than Unity's event system.

To use it, just place it in your Asset folder and make calls in any of your scripts like:


if (EZXR.isLeftTriggerPressed()){print ("YIPPEE");}


Vector2 pad = EZXR.leftTouchPadTouched();

Available Functions:

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
