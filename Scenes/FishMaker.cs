using System.Collections;
using UnityEngine;


public class FishMaker : MonoBehaviour
{
    public Transform FishHolder;
    public Transform[] genPositions;//存储生成位置
    public GameObject[] Fish;//鱼
    public float WaitTime = 0.3f;//等待时间
    public float WaitFishMake = 0.5f;

    void Start ()
    {
        //InvokeRepeating("MakeFishes", 0, WaitTime);//重复执行的时间间隔
        //MakeFishes();
        int num = Fish[0].GetComponent<FishAttr>().maxNum;
        for (int i = 0; i < num; i++)
        {
            StartCoroutine(MakeFishes());
        }
        
	}
    IEnumerator MakeFishes()
    {
        int genPosIndex = Random.Range(0,genPositions.Length);
        int fishPreIndex = Random.Range(0, Fish.Length);//在鱼的种类中随机生成一种鱼
        int maxSpeed = Fish[fishPreIndex].GetComponent<FishAttr>().maxSpeed;
        int speed = Random.Range(maxSpeed / 2, maxSpeed);//获取鱼的速度
        int angOffect = Random.Range(-22, 22);   //直走的倾斜角
        //int angSpeed;    //转弯的角速度     
        GameObject fish = Instantiate(Fish[fishPreIndex]);
        fish.transform.SetParent(FishHolder, false);
        fish.transform.position = genPositions[genPosIndex].position;
        fish.transform.rotation = genPositions[genPosIndex].rotation;
        fish.AddComponent<FishMove>().speed = speed;
        yield return new WaitForSeconds(WaitFishMake);
    }   
}
