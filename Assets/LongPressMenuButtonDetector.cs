using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class LongPressDetector : MonoBehaviour
{
    public UnityEvent onLongPress; // Event to invoke after a long press
    public SignalEmitter resetGameSignal;

    private InputDevice leftController;
    private bool isButtonPressed = false;
    private float buttonPressTime;
    private const float requiredPressDuration = 2.0f; // Seconds

    void Start()
    {
        InitializeLeftController();
    }

    void Update()
    {
        CheckLongPress();
    }

    private void InitializeLeftController()
    {
        leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    private void CheckLongPress()
    {
        if (!leftController.isValid)
        {
            InitializeLeftController();
            return;
        }

        leftController.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonValue);

        if (menuButtonValue && !isButtonPressed)
        {
            isButtonPressed = true;
            buttonPressTime = Time.time;
        }
        else if (!menuButtonValue && isButtonPressed)
        {
            isButtonPressed = false;
        }

        if (isButtonPressed && (Time.time - buttonPressTime >= requiredPressDuration))
        {
            isButtonPressed = false;
            onLongPress.Invoke();
        }
    }
}
