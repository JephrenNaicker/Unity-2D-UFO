using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{


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

        addStartForce();
    }

    // Update is called once per frame
    void Update()
    {

         transform.Rotate(new Vector3(0,0,-45)*Time.deltaTime);

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
