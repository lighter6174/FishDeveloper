
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerDownHandler
{
    public GameObject canvas;
    public static StartGame Instance; //实例化本类
    public bool isStartGame=true;
    void Awake()
    {
        Instance = this; //赋值

    }
    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        int fishnums = GameObject.Find("MainScreen").GetComponent<ClickObject>().addfishnum;
        GameObject.Find("Hook").GetComponent<HookFish>().fishnum = fishnums;
        //Debug.Log("这是鱼在游戏中的数量"+fishnums);
        if (isStartGame)
        {
            int HookMSpeed = 1;
            int CmaraMSpeed = 30;
            canvas.gameObject.SetActive(false);
            //Find方法 如果 该查找对象是隐藏的 查找不到
            GameObject.Find("FishHook").GetComponent<LineDown>().MoveDownSpeed = HookMSpeed;
            GameObject.Find("FishHook").GetComponent<LineDown>().MoveUpSpeed = HookMSpeed;
            GameObject.Find("Main Camera").GetComponent<CmaraFllow>().MoveSpeed = CmaraMSpeed;
            GameObject.Find("FishHook").GetComponent<LineDown>().Gameflag = 1;
            GameObject.Find("FishHook").GetComponent<LineDown>().flag = 0;         
        }
    }
}