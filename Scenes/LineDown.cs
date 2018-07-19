
using System.Collections;

using UnityEngine;


public class LineDown : MonoBehaviour
{
    public GameObject canvas;
    public float MoveDownSpeed = 0;
    private float angle;
    public GameObject FishHook;
    public float MoveUpSpeed = 0f;
    public int flag = 0;//控制下降
    public int Gameflag = 0;
    private Quaternion To = Quaternion.Euler(new Vector3(0, 0, 0));
    public float length = -50f;
    public GameOver gameOver;
    //public CmaraFllow camarafllow;
    Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
    Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    Vector3 mousePositionInWorld;//获取到世界坐标
    Vector3 targetposition;
    
    void Update ()
    {
        if (Gameflag ==1)
        {
            GetMousePosition();
            HookMove();
        }
      
    }
    void GetMousePosition()
    {
        //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //获取鼠标在场景中坐标
        mousePositionOnScreen = Input.mousePosition;
        //让场景中的Z=鼠标坐标的Z
        mousePositionOnScreen.z = screenPosition.z;
        //将相机中的坐标转化为世界坐标
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
    }
    void HookMove()
    {

        if (transform.position.y >= length + 50 && flag == 0)
        {
            MoveWithMouse();           
        }
        else if(transform.position.y >= length && transform.position.y<=length + 50 &&  flag == 0)
        {
            MoveDownSpeed = 10;
            MoveUpSpeed = 10;
            MoveWithMouse();
            GameObject.Find("Main Camera").GetComponent<CmaraFllow>().MoveSpeed =10;
            //camarafllow.MoveSpeed = 10f;
           //StartGame.Instance.camera
        }
        else
        {
            flag = 1;
            GameObject.Find("Main Camera").GetComponent<CmaraFllow>().flag = 1;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(Vector3.up * MoveUpSpeed * Time.deltaTime);
            if(transform.position.y <= -4 && transform.position.y >= -14)
            {
                //上升过程中速度下降
            }
        }
        if (transform.position.y >= -4 && flag ==1)
        {
            //MoveUpSpeed = 0;
            Gameflag = 0;
            flag = 2;
            //canvas.gameObject.SetActive(true);
            gameOver.RemoveAllListViewItem();
            StartGame.Instance.isStartGame = true;

        }

    }
    void MoveWithMouse()
    {
        transform.Translate(Vector3.down * MoveDownSpeed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            //transform.Translate(Vector3.down * MoveDownSpeed * Time.deltaTime);
            /*if (mousePositionInWorld.x >= 356 && mousePositionInWorld.x <= 364)
            {
                angle = (Mathf.Rad2Deg * Mathf.Atan((transform.position.x - mousePositionInWorld.x) / (transform.position.y - mousePositionInWorld.y))) * 1.5f;
                //transform.Translate(Vector3.down * MoveDownSpeed * Time.deltaTime);
                //不是平滑的移动
                //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //transform.position = new Vector3(mousePositionInWorld.x, transform.position.y, transform.position.z);
                
                targetposition = mousePositionInWorld;
                targetposition.y = transform.position.y;
                To = Quaternion.AngleAxis(angle, Vector3.back);
                transform.rotation = Quaternion.Slerp(transform.rotation, To, Time.deltaTime * 1.7f);
                transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * 3.0F);
               

            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
               // transform.Translate(Vector3.down * MoveDownSpeed * Time.deltaTime);
            }*/
            angle = (Mathf.Rad2Deg * Mathf.Atan((transform.position.x - mousePositionInWorld.x) / (transform.position.y - mousePositionInWorld.y))) * 1.0f;
            targetposition = mousePositionInWorld;
            targetposition.y = transform.position.y;
            To = Quaternion.AngleAxis(angle, Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, To, Time.deltaTime * 1.6f);
            transform.position = Vector3.Lerp(transform.position, targetposition, Time.deltaTime * 3.0F);
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //transform.Translate(Vector3.down * MoveDownSpeed * Time.deltaTime);
        }

    }
}

