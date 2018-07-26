using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSea : MonoBehaviour
{
    public GameObject[] Sea;
    private static int num = 0;
    private Vector3 pos = new Vector3(360,num,0);
    void Start ()
    {
        /*for(int i = 0;i<=4;i++)
        {
            pos1 = new Vector3(360, pos1.y - 12, 0);
            Instantiate(Sea1, pos1, Quaternion.identity);
        }
        for (int i = 0; i <= 4; i++)
        {
            pos2 = new Vector3(360, pos2.y - 12, 0);
            Instantiate(Sea2, pos2, Quaternion.identity);
        }*/

        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                num = num - 10;
                pos = new Vector3(360,num,0);
                Instantiate(Sea[i], pos, Quaternion.identity);
            }

        }
    }
	
}
