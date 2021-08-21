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
    Vector3 pos;

    //  int Randomx=Random.Range(0,5);

    // int Randomy=Random.Range(5,10);
    void Start()
    {
        pos = transform.position;

          transform.position = new Vector3(Random.Range(-15,10), Random.Range(-30,5), transform.position.z+2) ;


        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,45)*Time.deltaTime);
         //Vector3 pos = transform.position;
         //calculate what the new Y position will be
         float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
         //set the object's Y to the new calculated Y
         transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;


    }







}
