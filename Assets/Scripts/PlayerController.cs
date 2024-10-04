using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum State
    {
        Playing,
        Dead
    }
    
    public float speed = 5;
    public float JumpSpeed = 5;
    public Collider2D BottomCollider;
    public CompositeCollider2D TerrainCollider;
    public CompositeCollider2D UpperTerrainCollider;
    private bool grounded;
    private bool uppergrounded;
    float vx = 0;
    float prevVx = 0;
    private State state;
    Vector2 originalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
        state = State.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        if(state!=State.Playing)
        {
            return;
        }
        
        vx = Input.GetAxisRaw("Horizontal") * speed;
        float vy = GetComponent<Rigidbody2D>().linearVelocityY;
       
        if (vx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (vx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (BottomCollider.IsTouching(TerrainCollider))
        {
            if(!grounded)
            {
                if (vx == 0)
                {
                    GetComponent<Animator>().SetTrigger("Idle");
                }
                else
                {
                    GetComponent<Animator>().SetTrigger("Run");
                }
            }
            else
            {
                if (vx != prevVx)
                {
                    if (vx == 0)
                    {
                        GetComponent<Animator>().SetTrigger("Idle");
                        
                    }
                    else
                    {
                        GetComponent<Animator>().SetTrigger("Run");
                        
                    }
                    
                    
                }
            }
        }
        else
        {
            if (grounded)
            {
                GetComponent<Animator>().SetTrigger("Jump");
            }
        }
        
        
        grounded = BottomCollider.IsTouching(TerrainCollider);
        // uppergrounded = BottomCollider.IsTouching(UpperTerrainCollider);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            vy = JumpSpeed;
        }
        //아래로 동장할때
        
        
        
        
        prevVx = vx;
        
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(vx, vy);
    }
    
    public void Restart()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        GetComponent<BoxCollider2D>().enabled = true;
        
        transform.eulerAngles = Vector3.zero;
        state = State.Playing;
        transform.position = originalPosition;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
           Die();
        }
    }

    private void Die()
    {
        state = State.Dead;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().angularVelocity = 720;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
        GetComponent<BoxCollider2D>().enabled = false;
        GameManager.Instance.Die();
    }
}
