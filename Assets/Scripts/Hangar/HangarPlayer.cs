using Hangar;
using UnityEngine;

namespace _Game.Scripts.Hangar
{
    public class HangarPlayer : MonoBehaviour
    {
        public HangarPlayerAnimStates animStates;
        [SerializeField] private int diamonds;
        [SerializeField] private int scrapParts;
        [SerializeField] private int dynamites;
        public HangarMiner hangarMiner;
        public HangarView view;

        private void Start()
        {
            animStates = HangarPlayerAnimStates.Idle;
            view.UpdateUI(dynamite:dynamites,diamond:diamonds,scrapMetal:scrapParts);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("anyTrigger Tag: "+ other.tag);
            if (other.tag.Equals("Hangar_Miner"))
            {
                if (dynamites > 0)
                {
                    hangarMiner.TransferDynamitesIn(dynamites);
                    dynamites = 0;
                    view.UpdateUI(dynamite:0);
                }
                
                Debug.Log("Triggered Miner Area");
            }
            if (other.tag.Equals("Hangar_Miner_OffLoad"))
            {
                diamonds += hangarMiner.TransferDiamondsOut();
                view.UpdateUI(diamond:diamonds);
                Debug.Log("Diamonds Received. Amount: "+diamonds);
            }
        }
    }
}
