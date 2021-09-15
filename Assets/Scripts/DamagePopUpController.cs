using System;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
//using System.Threading;
//using System.Threading.Tasks.Dataflow;
//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUpController : MonoBehaviour
{

public Transform pfDamagePopUp;
public float disapperTimer;
private TextMeshPro textMesh;
private Color textColor;

private DamagePopUpController ()
{

}

 private void Awake()  
 {
     textMesh = transform.GetComponent<TextMeshPro>();
 }

   
   public  void SetDamageText(float damageAmt)//
   {
      textMesh.SetText(damageAmt.ToString());
      textColor = textMesh.color;
      disapperTimer=1f;

   }

   private void Update() {
       float moveYSpeed = 0.40f;
       transform.position+= new Vector3(0,moveYSpeed)*Time.deltaTime;

       disapperTimer-= Time.deltaTime;
       if(disapperTimer<0)
       {
        //Start Disappaering
        float disapperSpeed =3f;
        textColor.a-= disapperSpeed * Time.deltaTime;
        textMesh.color= textColor;
        Destroy(gameObject);
       }
    


   }


//    public  static DamagePopUpController Create(Vector3 postion,float damageAmt)
// {
//       Transform damagePopUpTransform = Instantiate(pfDamagePopUp,Vector3.zero,Quaternion.identity);
//       //DamagePopUpController   damagePopUpC = new DamagePopUpController();
//       //=damagePopUpTransform.GetComponent<DamagePopUpController>();
//       damagePopUpC.Setup(damageAmt);
       
//        return damagePopUpC;
// }
}
