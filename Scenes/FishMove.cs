
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 dir = Vector3.right;
    SpriteRenderer fishSpriteRenderer;
    Vector3 HookPosition;
    public int flag = 0;
   
    void Start()
    {
        fishSpriteRenderer = GetComponent<SpriteRenderer>();
        fishSpriteRenderer.flipX = true;
    }
    void Update ()
    {
        
        FishBack();     
    }
    void FishBack()
    {
        if (transform.position.x > 363 && fishSpriteRenderer.flipX == true)
        {
            fishSpriteRenderer.flipX = false;
            dir = Vector3.left;
            transform.Translate(dir * speed * Time.deltaTime);
        }
        else if (transform.position.x < 356 && fishSpriteRenderer.flipX == false)
        {
            dir = Vector3.right;
            fishSpriteRenderer.flipX = true;
            transform.Translate(dir * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
    
}
