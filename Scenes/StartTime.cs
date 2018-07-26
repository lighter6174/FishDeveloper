
using UnityEngine;

public class StartTime : MonoBehaviour
{
    public float spendTime;
    public int minute;
	void Update ()
    {
        spendTime += Time.deltaTime;
        minute = (int)(spendTime / 60);
        Debug.Log(minute);
	}
}
