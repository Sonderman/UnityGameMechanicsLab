using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputManager : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 position, float time);

    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent(Vector2 position, float time);

    public event EndTouchEvent OnEndTouch;

    private TouchInputControls _touchInputControls;

    private void Awake()
    {
        _touchInputControls = new TouchInputControls();
    }

    private void OnEnable()
    {
        _touchInputControls.Enable();
    }

    private void OnDisable()
    {
        _touchInputControls.Disable();
    }

    private void Start()
    {
        _touchInputControls.Touch.TouchPress.started += StartTouch;
        _touchInputControls.Touch.TouchPress.canceled += EndTouch;
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started" + _touchInputControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null)
            OnStartTouch(_touchInputControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Ended");
        if (OnEndTouch != null)
            OnEndTouch(_touchInputControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }
}