using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointsManager : MonoBehaviour
{

    public float pointsNumber;
    public float wiarygodnoscNumber;

    
    public Slider slider;
    public Slider wiarygodnosc;


    public void AddPointsToLiarMeter(float pointsToAdd)
    {
        pointsNumber += pointsToAdd;
    }

    public void AddPointsToWiarygodnoscXD(float pointsToAdd)
    {
        wiarygodnoscNumber += pointsToAdd;
    }

    private void Update() 
{
        slider.value = pointsNumber;
        wiarygodnosc.value = wiarygodnoscNumber;
    }
}
