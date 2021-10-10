using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{



//adjust this to change speed
[SerializeField]
float speed = 5f;
//adjust this to change how high it goes
[SerializeField]
float height = 0.5f;
    // Start is called before the first frame update
    UnityEngine.Vector3 pos;

     //float RandomX=(float)Random.Range(-13.9,9.02);

     //float RandomY=(float)Random.Range(11.36,-11.09);
    void Start()
    {
        pos = transform.position;

          //transform.position = new Vector3(Random.Range(-10,10), Random.Range(-30,5), transform.position.z+2) ;
          if (PlayerController.GetCurrentActiveScene()==1)
        /*Level 1*/
          transform.position = new UnityEngine.Vector3(Random.Range(-13,9),Random.Range(-11,11), transform.position.z) ;
          else if(PlayerController.GetCurrentActiveScene()==2)
          /*Level 2*/
           transform.position = new UnityEngine.Vector3(Random.Range(-25,24),Random.Range(-11,11), transform.position.z) ;
          else if(PlayerController.GetCurrentActiveScene()==3)
          /*Level 3*/
           transform.position = new UnityEngine.Vector3(Random.Range(-15,51),Random.Range(-14,20), transform.position.z) ;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new UnityEngine.Vector3(0,0,45)*Time.deltaTime);
         //Vector3 pos = transform.position;
         //calculate what the new Y position will be
         float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
         //set the object's Y to the new calculated Y
         transform.position = new UnityEngine.Vector3(transform.position.x, newY, transform.position.z) ;


    }







}
