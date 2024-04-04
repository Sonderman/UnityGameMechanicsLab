using UnityEngine;

namespace _Game.Scripts.Hangar
{
    public enum HangarPlayerAnimStates
    {
        Idle,
        Running,
        HoldRunning,
        Crafting
    }

    public class HangarPlayerAnimController : MonoBehaviour
    {
        private HangarPlayer player;
        private Animator animator;

        private void Start()
        {
            player = GetComponent<HangarPlayer>();
            animator = GetComponent<Animator>();
        }

        public void SetAnimSpeed(float speed)
        {
            animator.SetFloat("AnimSpeed",speed);
        }

        public void SetAnimationState(HangarPlayerAnimStates state)
        {
            if (state != player.animStates)
            {
                switch (state)
                {
                    case HangarPlayerAnimStates.Idle:
                        animator.SetTrigger("Idle");
                        player.animStates = HangarPlayerAnimStates.Idle;
                        break;
                    case HangarPlayerAnimStates.Running:
                        animator.SetTrigger("Run");
                        player.animStates = HangarPlayerAnimStates.Running;
                        break;
                    case HangarPlayerAnimStates.HoldRunning:
                        animator.SetTrigger("HoldRun");
                        player.animStates = HangarPlayerAnimStates.HoldRunning;
                        break;
                    case HangarPlayerAnimStates.Crafting:
                        animator.SetTrigger("Craft");
                        player.animStates = HangarPlayerAnimStates.Crafting;
                        break;
                }
            }
        }
    }
}