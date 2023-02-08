using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuControle : MonoBehaviour
{
    public GameObject box1, box2, box3, box4, box5;

    private void Start()
    {
        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(false);
        box4.SetActive(false);
        box5.SetActive(false);
    }

    private void OnMouseOver()
    {
        box1.SetActive(true);
        box2.SetActive(true);
        box3.SetActive(true);
        box4.SetActive(true);
        box5.SetActive(true);
    }
    private void OnMouseExit() 
    {
        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(false);
        box4.SetActive(false);
        box5.SetActive(false);
    }
}
