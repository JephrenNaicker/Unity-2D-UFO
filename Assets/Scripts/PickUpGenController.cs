using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUpGenController : MonoBehaviour
{

  public Text txtCountPickUp;
   int CountPickUp;
   bool count;
    public GameObject[] PickUpObj;
    private Vector3 SpawnPickobjPostion;
    // Start is called before the first frame update
    void Start()
    {
        CountPickUp= 0;
        count=true;
        txtCountPickUp.text="";
        //getpickUpCount();
    // Instantiate(PickUpObj[(Random.Range(5,PickUpObj.Length))],SpawnPickobjPostion,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       // getpickUpCount();
       //txtCountPickUp.text ="PickUpCount"+CountPickUp;
    }

    public int getpickUpCount()
    {

       

        for(int x =0;x<=PickUpObj.Length;x++)
        {
            if(count){
            Debug.Log("Array Lenght: "+PickUpObj.Length);
            CountPickUp++;
            }
            
        }

         // txtCountPickUp.text ="PickUpCount"+CountPickUp.ToString();

       return CountPickUp;
    }


}
