
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public HookFish hookFish;
    public ClickObject clickObject;
    public void RemoveAllListViewItem()
    {
        
        GameObject obj = GameObject.Find("FishHook/Hook");
        clickObject.currentmoney = clickObject.currentmoney + hookFish.money;
        //clickObject.SendMessage("ShowMoney",clickObject.currentmoney);
        if (clickObject.currentmoney > clickObject.cost)
        {
            clickObject.NoUpgrade.gameObject.SetActive(false);
        }
        hookFish.money = 0;
        foreach (Transform child in obj.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
