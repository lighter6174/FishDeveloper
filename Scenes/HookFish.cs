
using UnityEngine;

public class HookFish : MonoBehaviour
{

    public GameObject Fish;
    public int fishnum = 2;
    public float HookLength = 0;
    public float money =0;
    void Update ()
    {
        Fish = GameObject.FindWithTag("Fish");     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.y <= HookLength)
        {
            if (collision.gameObject.tag == "Fish")
            {
                fishnum = fishnum - 1;
                //GameObject.Find("SpringHolder").GetComponent<FishMove>().speed = 0;
                if (fishnum >= 0)
                {
                    collision.gameObject.GetComponent<FishMove>().speed = 0;
                    money = collision.gameObject.GetComponent<FishAttr>().money + money;
                    collision.gameObject.transform.parent = this.gameObject.transform;
                    Vector3 v = collision.gameObject.transform.localPosition;
                    v.y = 0.1f;
                    v.x = 0.1f;
                    collision.gameObject.transform.localPosition = v;
                }
                else
                {
                    return;
                }

            }
        }
    }
}
