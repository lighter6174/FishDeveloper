
using UnityEngine;


public class CmaraFllow : MonoBehaviour {


    
    public Transform followTarget;
    public int flag = 0;
    public float MoveSpeed = 0;
    void Update()
    {
        MoveCamara();
    }
    void MoveCamara()
    {
        if ((transform.position.y - followTarget.position.y) < -4 && flag == 0)
        {
            GameObject.Find("FishHook").GetComponent<LineDown>().MoveDownSpeed = 30;
            GameObject.Find("FishHook").GetComponent<LineDown>().MoveUpSpeed = 30;
            transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);

        }
        else if (flag == 1)
        {
            if (transform.position.y >= 2)
            {
                MoveSpeed = 0;
                flag = 0;
                return;
            }
            MoveSpeed = 30;
            transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);          
        }
        else
        {
            transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
        }      
    }   
}
