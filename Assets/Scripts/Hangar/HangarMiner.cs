using TMPro;
using UnityEngine;


namespace _Game.Scripts.Hangar
{
    public class HangarMiner : MonoBehaviour
    {
        public bool debugLog;
        public int requiredDynamiteAmount = 1;
        public int convertedDynamiteAmount = 1;
        [SerializeField] private int loadedDynamites = 0;
        [SerializeField] private int offLoadDiamonds = 0;
        public float convertSpeed = 1f;
        private bool isConverting;
        public TextMeshProUGUI loadedDynamiteText;
        public TextMeshProUGUI offLoadDiamondText;
        public BoxCollider offLoadCollider;
        private Animator animator;
        private bool isAnimBlast;

        void Start()
        {
            animator = GetComponent<Animator>();
            loadedDynamiteText.text = loadedDynamites.ToString();
            offLoadDiamondText.text = offLoadDiamonds.ToString();
        }

        public void TransferDynamitesIn(int amount)
        {
            loadedDynamites += amount;
            loadedDynamiteText.text = loadedDynamites.ToString();
            if (debugLog)
                Debug.Log("Dynamites Transferred. Amount: " + amount);
        }

        public int TransferDiamondsOut()
        {
            int amount = offLoadDiamonds;
            offLoadDiamonds = 0;
            offLoadDiamondText.text = "0";
            if (debugLog)
                Debug.Log("Diamonds Transferred. Amount: " + amount);
            return amount;
        }

        void FixedUpdate()
        {
            offLoadCollider.enabled = offLoadDiamonds > 0;
            if (isConverting)
            {
                if (!isAnimBlast)
                {
                    animator.SetTrigger("Blast");
                    isAnimBlast = true;
                }

                if (loadedDynamites < requiredDynamiteAmount)
                {
                    CancelInvoke(nameof(ConvertDynamitesToDiamonds));
                    isConverting = false;
                }
            }
            else
            {
                if (isAnimBlast)
                {
                    animator.SetTrigger("Idle");
                    isAnimBlast = false;
                }

                if (loadedDynamites >= requiredDynamiteAmount)
                {
                    InvokeRepeating(nameof(ConvertDynamitesToDiamonds), 0.5f, convertSpeed);
                    isConverting = true;
                }
            }
        }

        void ConvertDynamitesToDiamonds()
        {
            if (debugLog)
                Debug.Log("Convert invoked");
            if (loadedDynamites >= requiredDynamiteAmount)
            {
                loadedDynamites -= requiredDynamiteAmount;
                offLoadDiamonds += convertedDynamiteAmount;
                loadedDynamiteText.text = loadedDynamites.ToString();
                offLoadDiamondText.text = offLoadDiamonds.ToString();
                if (debugLog)
                    Debug.Log("Converted");
            }
        }
    }
}