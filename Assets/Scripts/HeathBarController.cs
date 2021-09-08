using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarController : MonoBehaviour
{


    public Slider slider;
    public Gradient gradient;
    public Image fill;

public void SetMaxHealth(float health)
{
 slider.maxValue = health;
 slider.value = health;

}

   public void setHealth(float health)
   {
       slider.value = health;
       fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
