using System.Collections;

using UnityEngine;

public class Hook : MonoBehaviour
{
    public float Positiony = -10;
    void Start()
    {

    }
    void Update()
    {
        Positiony -= 0.08f;
        transform.localPosition = new Vector3(1,Positiony, 0);
    }

}
