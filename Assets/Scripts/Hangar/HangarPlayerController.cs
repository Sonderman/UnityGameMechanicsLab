using UnityEngine;

namespace _Game.Scripts.Hangar
{
    [RequireComponent(typeof(UnityEngine.CharacterController))]
    public class HangarPlayerController : MonoBehaviour
    {
        public float movementSpeed = 1f;
        public FloatingJoystick floatingJoystick;
        public float smoothTime = 0.05f;
        private float currentVelocity;
        private HangarPlayerAnimController animController;
        private UnityEngine.CharacterController characterController;

        private void Start()
        {
            animController = GetComponent<HangarPlayerAnimController>();
            characterController = GetComponent<UnityEngine.CharacterController>();
        }

        public void LateUpdate()
        {
            Vector3 fdirection = Vector3.forward * floatingJoystick.Vertical +
                                 Vector3.right * floatingJoystick.Horizontal;
            Vector2 input = new Vector2(floatingJoystick.Horizontal, floatingJoystick.Vertical);

            if (input.sqrMagnitude != 0)
            {
                var targetAngle = Mathf.Atan2(fdirection.x, fdirection.z) * Mathf.Rad2Deg;
                var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity,
                    smoothTime);
                transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                characterController.Move(fdirection * movementSpeed * Time.deltaTime);
                animController.SetAnimationState(HangarPlayerAnimStates.Running);
                animController.SetAnimSpeed(input.magnitude);
            }
            else
            {
                animController.SetAnimationState(HangarPlayerAnimStates.Idle);
                animController.SetAnimSpeed(1f);
            }
        }
    }
}