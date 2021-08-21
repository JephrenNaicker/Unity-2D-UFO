using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    //adjust this to change speed
//[SerializeField]
//float speed = 5f;
//adjust this to change how high it goes
///[SerializeField]
//float height = 0.5f;
    // Start is called before the first frame update
     Vector3 pos;
    Rigidbody2D m_Rigidbody;

    [SerializeField]
        public float m_Speed;    
    
    
   private void Awake() 
   {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Speed=250f;    

   }


  private  void Start()
    {
        pos = transform.position;
             //Fetch the Rigidbody component you attach from your GameObject
       transform.Rotate(new Vector3(0,0,-45)*Time.deltaTime);
        //Set the speed of the GameObject
        addStartForce();
    }

    // Update is called once per frame
    void Update()
    {
      // m_Rigidbody.velocity = transform.forward * m_Speed;

         //float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
         //set the object's Y to the new calculated Y
         //transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;

        //transform.position = new Vector3(transform.position.x,newY, transform.position.z) ;

    }



    //  private void OnCollisionEnter2D(Collision2D other) 
    //  {
    
    //     if(other.gameObject.CompareTag("Wall"))
    //     {
          
    //       Debug.Log("can see wall");
    //     //   transform.Rotate(new Vector3(0,0,55)*Time.deltaTime);
    //     //   Debug.Log("Rotate");
    //     //    transform.Translate(Vector3.left * Time.deltaTime);

    //        //m_Rigidbody.velocity = transform.forward * m_Speed;
    //        addStartForce();
    //        //transform.Rotate(Vector3.left * Time.deltaTime);

    //     }
    // }


    private void addStartForce()
    {

       float x = Random.value  < 0.5f ? -1.0f :1.0f;

        float y = Random.value  < 0.5f ? Random.Range(-1.0f,-0.5f):
                                         Random.Range(-1.0f,-0.5f);
         Vector2 ChangeDirection = new Vector2(x,y);
        m_Rigidbody.AddForce(ChangeDirection * m_Speed);


    }



}
