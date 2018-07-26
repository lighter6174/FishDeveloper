
using UnityEngine;
using UnityEngine.UI;

public class ClickObject : MonoBehaviour
{
    public float currentlength = -50f;
    public float currentmoney = 200;
    public int currenfish = 0;
    public float cost = 0;
    public int costnum = 1;
    public int addfishnum = 2;
    public int addtimemoney = 1;
    public float time = 0;
    public float leftmoney;
    public int flag = 0;//标注点击事件
    public int settingflag = 0;
    public int soundflag = 0;
    public Button[] buttonArray;
    public GameObject Board;
    public GameObject Money;
    public GameObject Type;
    public GameObject Bounder;
    public StartTime startTime;
    public GameObject ShowCost;
    public GameObject ShowCostcost;
    public GameObject NoUpgrade;
    public GameObject AD;
    public GameObject Sound;
    public GameObject NoSound;
    
    //public List<Button> btton_All = new List<Button>();

    void Start ()
    {
        Button btn1 = GameObject.Find("MainScreen/Length").GetComponent<Button>();
        Button btn2 = GameObject.Find("MainScreen/Strength").GetComponent<Button>();
        Button btn3 = GameObject.Find("MainScreen/Setting").GetComponent<Button>();
        Button btn4 = GameObject.Find("MainScreen/Offline").GetComponent<Button>();
        //Button btn5 = GameObject.Find("MainScreen/AD").GetComponent<Button>();
        Button btn5 = AD.GetComponent<Button>();
        Button btn6 = GameObject.Find("MainScreen/Setting").GetComponent<Button>();
        Button btn7 = GameObject.Find("MainScreen/Side/Upgrade").GetComponent<Button>();
        //Button btn8 = GameObject.Find("MainScreen/Sound").GetComponent<Button>();
        Button btn8 = Sound.GetComponent<Button>();
        ShowMoney(currentmoney);
        btn1.onClick.AddListener(AddLength);
        btn2.onClick.AddListener(AddFish);
        btn3.onClick.AddListener(Setting);
        btn4.onClick.AddListener(AddOfflineMoney);
        btn7.onClick.AddListener(Changed);
        btn8.onClick.AddListener(ControSound);
        InvokeRepeating("AddTimeMoney", 60, 60);
    }
    void AddLength()
    {
        PlaySound();
        Color color = new Color(230 / 255f, 86 / 255f, 78 / 255f, 255 / 255f);
        Bounder.GetComponent<Image>().color = color;
        flag = 1;
        ShowLength(currentlength);
    }
    void AddFish()
    {
        PlaySound();
        Color color = new Color(95/255f,172/255f,225/255f,255/255f);
        Bounder.GetComponent<Image>().color = color;
        flag = 2;
        ShowFish(addfishnum);
    }
    void AddOfflineMoney()
    {
        PlaySound();
        Color color = new Color(128/255f,216/255f,107/255f,255/255f);
        Bounder.GetComponent<Image>().color = color;
        flag = 3;
        ShowOffline(addtimemoney);
    }
    void AddTimeMoney()
    {
        //time = startTime.minute;
        currentmoney = currentmoney + (int)(2 * Mathf.Pow(1.2f, addtimemoney));
        ShowMoney(currentmoney);
    }
    void ShowLength(float n)
    {
        cost = Mathf.Ceil(120 * Mathf.Pow(1.2f,costnum));
        ShowCostMoney(cost);
        if (currentmoney >= cost)
        {
            NoUpgrade.gameObject.SetActive(false);
        }
        else
        {
            NoUpgrade.gameObject.SetActive(true);
        }
        n = -(currentlength - 10);
        Type.GetComponent<Text>().text = "LENGRH";       
        Board.GetComponent<Text>().text = n.ToString()+"M";
    }
    void ShowFish(int n)
    {
        cost = Mathf.Ceil(120 * Mathf.Pow(1.2f, n - 1));
        ShowCostMoney(cost);
        if (currentmoney >= cost)
        {
            NoUpgrade.gameObject.SetActive(false);
        }
        else
        {
            NoUpgrade.gameObject.SetActive(true);
        }
        n += 1;
        Type.GetComponent<Text>().text = "STRENGTH";
        Board.GetComponent<Text>().text = n.ToString() + "Fish";     
    }
    void ShowOffline(float n)
    {
        cost = Mathf.Ceil(120 * Mathf.Pow(1.2f, n));
        ShowCostMoney(cost);
        if (currentmoney >= cost)
        {
            NoUpgrade.gameObject.SetActive(false);
        }
        else
        {
            NoUpgrade.gameObject.SetActive(true);
        }
        n = (int)(2 * Mathf.Pow(1.2f, n+1));
        Type.GetComponent<Text>().text = "Time";
        Board.GetComponent<Text>().text = n.ToString() + "$/min";
    }
    void ShowMoney(float n)
    {
        Money.GetComponent<Text>().text = n.ToString();
    }
    void ShowCostMoney(float m)
    {
        float showCost = m;
        ShowCost.GetComponent<Text>().text = showCost.ToString();
        ShowCostcost.GetComponent<Text>().text = showCost.ToString();
    }
    void Changed()
    {
        if (soundflag == 0)
        {
            SoundManager.Instance.PlaySoundEffect("FM_upgrade");

        }
        SoundManager.Instance.PlaySoundEffect("FM_upgrade");
        if (flag == 1 || flag == 0)
        {
            
            leftmoney = currentmoney - Mathf.Ceil(120 * Mathf.Pow(1.2f, costnum));
            //Debug.Log(currentmoney);
            if (leftmoney >= 0)
            {
                currentmoney = currentmoney - Mathf.Ceil(120 * Mathf.Pow(1.2f, costnum));
                costnum = costnum + 1;
                cost = Mathf.Ceil(120 * Mathf.Pow(1.2f, costnum));
                ShowCostMoney(cost);
                if (cost >= currentmoney)
                {
                    NoUpgrade.gameObject.SetActive(true);
                }
                else
                {
                    NoUpgrade.gameObject.SetActive(false);
                }
                currentlength = currentlength - 10;
                ShowLength(currentlength);
                ShowMoney(currentmoney);
                GameObject.Find("FishHook").GetComponent<LineDown>().length = currentlength;
                GameObject.Find("Hook").GetComponent<HookFish>().HookLength = currentlength + 50.0f;
            }
            else
            {
                NoUpgrade.gameObject.SetActive(true);
            }
        }
        if (flag == 2)
        {
            leftmoney = currentmoney - Mathf.Ceil(120 * Mathf.Pow(1.2f, addfishnum-1));
            if (leftmoney >= 0)
            {
                currentmoney = currentmoney - Mathf.Ceil(120 * Mathf.Pow(1.2f, addfishnum - 1));
                cost = Mathf.Ceil(120 * Mathf.Pow(1.2f, addfishnum - 1));
                ShowCostMoney(cost);
                if (cost >= currentmoney)
                {
                    NoUpgrade.gameObject.SetActive(true);
                }
                else
                {
                    NoUpgrade.gameObject.SetActive(false);
                }
                addfishnum = addfishnum + 1;
                ShowMoney(currentmoney);
                ShowFish(addfishnum);
                GameObject.Find("Hook").GetComponent<HookFish>().fishnum = addfishnum;          
            }
            else
            {
                NoUpgrade.gameObject.SetActive(true);
            }
        }
        if (flag == 3)
        { 
            leftmoney = currentmoney - Mathf.Ceil(120 * Mathf.Pow(1.2f, addtimemoney));
            if(currentmoney > 0)
            {
                currentmoney = currentmoney - Mathf.Ceil(120 * Mathf.Pow(1.2f, addtimemoney));
                cost = Mathf.Ceil(120 * Mathf.Pow(1.2f,addtimemoney+1));
                ShowCostMoney(cost);
                if (cost >= currentmoney)
                {
                    NoUpgrade.gameObject.SetActive(true);
                }
                else
                {
                    NoUpgrade.gameObject.SetActive(false);
                }
                addtimemoney += 1;
                ShowOffline(addtimemoney);
                ShowMoney(currentmoney);
            }
            else
            {
                NoUpgrade.gameObject.SetActive(true);
            }
        }
    }
    void Setting()
    {
        PlaySound();
        if (settingflag == 0)
        {
            AD.gameObject.SetActive(true);
            //Sound.gameObject.SetActive(true);
            if (soundflag == 0)
            {
                NoSound.gameObject.SetActive(false);
            }
            
            settingflag = 1;
            return;
        }
        else
        {
            AD.gameObject.SetActive(false);
            //Sound.gameObject.SetActive(false);
            if (soundflag == 0)
            {
                NoSound.gameObject.SetActive(false);
            }
            settingflag = 0;
            return;
        }
    }
    void PlaySound()
    {
        if (soundflag == 0)
        {
            SoundManager.Instance.PlaySoundEffect("FM_click");

        }

    }
    void ControSound()
    {
        if (soundflag == 0)
        { 
            NoSound.gameObject.SetActive(true);
            soundflag = 1;
            return;
        }
        else
        {
            NoSound.gameObject.SetActive(false);
            soundflag = 0;
            return;
        }
    }

}
