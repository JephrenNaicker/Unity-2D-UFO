using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    [SerializeField]
    
    private Vector3 initialVelocity;

    [SerializeField]
    [Tooltip("Velocity on Bounce")]
    private float minVelocity = 6f;

    private Vector3 lastFrameVelocity;

    Rigidbody2D m_Rigidbody;

    [SerializeField]
    [Tooltip("Speed on Start")]
    public float m_Speed;    
    
   private void Awake() 
   {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Speed=300f;    
        m_Rigidbody.velocity = initialVelocity;
   }


  private  void Start()
    {
       int RandomRotation = Random.Range(-45,45);
         transform.Rotate(new Vector3(0,0, RandomRotation)*Time.deltaTime);
        addStartForce();
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity=m_Rigidbody.velocity;
    }



     private void OnCollisionEnter2D(Collision2D other) 
     {
    
        // if(other.gameObject.CompareTag("Wall"))
        // {
          
         // Debug.Log("can see wall");
         Bounce(other.contacts[0].normal);

        //}
    }


    private void addStartForce()
    {

       float x = Random.value  < 0.5f ? -1.0f :1.0f;

        float y = Random.value  < 0.5f ? Random.Range(-1.0f,-0.5f):
                                         Random.Range(-1.0f,-0.5f);
         Vector2 ChangeDirection = new Vector2(x,y);
        m_Rigidbody.AddForce(ChangeDirection * m_Speed);


    }

   private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //Debug.Log("Out Direction: " + direction);
        m_Rigidbody.velocity = direction * Mathf.Max(speed, minVelocity);
    }



}
