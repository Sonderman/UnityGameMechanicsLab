using TMPro;
using UnityEngine;

namespace Hangar
{
    public class HangarView : MonoBehaviour
    {
        public TextMeshProUGUI dynamiteText;
        public TextMeshProUGUI diamondText;
        public TextMeshProUGUI scrapPartsText;


        public void UpdateUI(int dynamite=-1,int diamond=-1,int scrapMetal=-1)
        {
            if (dynamite > -1) dynamiteText.text = dynamite.ToString();
            if (diamond > -1) diamondText.text = diamond.ToString();
            if (scrapMetal > -1) scrapPartsText.text = scrapMetal.ToString();
        }
        public void OnClickExitBtn()
        {
            //GameManager.Instance.sceneManager.LoadScene(Scenes.GraveyardScene);
        }
    }
}
