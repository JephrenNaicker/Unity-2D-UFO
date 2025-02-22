using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMatterPickUpController : MonoBehaviour
{

    private Vector3 initialVelocity;

    [SerializeField]
    [Tooltip("Velocity on Bounce")]
    public float minVelocity = 6f;

    private Vector3 lastFrameVelocity;

     private float DarkMatterInvert=0.50f;

     public  Material MovingPickUpInvertColour;

     public GameObject PlayerUFO;

     private Rigidbody2D rb2dDark;

    [SerializeField]
    [Tooltip("Speed on Start")]
    public float Speed;    

     public float DarkMatterDistanceRun= 7.0f;



   private void Awake() 
   {
         rb2dDark=GetComponent<Rigidbody2D>();
         Speed=250f;    
        rb2dDark.linearVelocity = initialVelocity;
   }

    // Start is called before the first frame update
    void Start()
    {

        
       
            addStartForce();
         //DarkMatterInvert = 0.50f;
         //MovingPickUpInvertColour.SetFloat("_Threshold",DarkMatterInvert);
         

    }

    // Update is called once per frame
    void Update()
    {
      lastFrameVelocity=rb2dDark.linearVelocity;
        //InvertDarkMatterColour();
      
       FleePlayer();
        
    }


 private void OnCollisionEnter2D(Collision2D other) 
     {
    
        // if(other.gameObject.CompareTag("Wall"))
        // {
          
         Debug.Log("I hit something");
         Bounce(other.contacts[0].normal);
         Debug.Log("I hit something too");
        //}
    }
    public void InvertDarkMatterColour()
    {
        // DarkMatterInvert=DarkMatter;
         /*
         50 - 75
         
         */
         while (DarkMatterInvert>=0.50f && DarkMatterInvert<=0.75f)
         {
            // DarkMatterInvert+=0.3f;
             //MovingPickUpInvertColour.SetFloat("_Threshold",DarkMatterInvert);

          if(DarkMatterInvert>=0.50f)
          {
            DarkMatterInvert+=0.05f;
            MovingPickUpInvertColour.SetFloat("_Threshold",DarkMatterInvert);
            Debug.Log("<"+DarkMatterInvert);
         }
         else
          if (DarkMatterInvert<=0.75f)
         {
               Debug.Log(">"+DarkMatterInvert);
               DarkMatterInvert-=0.05f;
               MovingPickUpInvertColour.SetFloat("_Threshold",DarkMatterInvert);
         }
         
         }
      }


      public void FleePlayer()
      {

         
       var distance = Vector3.Distance(transform.position,PlayerUFO.transform.position);
         // Debug.Log("Distance"+distance);
         

         if(distance<DarkMatterDistanceRun)
        {
            float x = Random.value  < 0.7f ? -3.0f :3.0f;
            float y = Random.value  < 0.7f ? Random.Range(-3.0f,-0.7f):
                                         Random.Range(-3.0f,-0.7f);

            Vector2 ChangeDirection = new Vector2(x,y);
            rb2dDark.AddForce(ChangeDirection * minVelocity);
    

         
        }
      }





    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //Debug.Log("Out Direction: " + direction);
        rb2dDark.linearVelocity = direction * Mathf.Max(speed, minVelocity);
    }


  private void addStartForce()
    {

       float x = Random.value  < 0.5f ? -1.0f :1.0f;

        float y = Random.value  < 0.5f ? Random.Range(-1.0f,-0.5f):
                                         Random.Range(-1.0f,-0.5f);
         Vector2 ChangeDirection = new Vector2(x,y);
        rb2dDark.AddForce(ChangeDirection * Speed);


    }


      

}
