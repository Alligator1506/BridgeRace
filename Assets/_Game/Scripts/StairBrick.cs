using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBrick : ColorObject
{
    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        ChangeColor(colorType);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((int)other.GetComponent<Character>().colorType != (int)colorType && (other.CompareTag("Player") || other.CompareTag("Enemy"))) //Nếu collider là người hoặc bot thì
        {
            if (other.GetComponent<Character>().BackBrickCount > 0)
            {
                ChangeColor(other.GetComponent<Character>().colorType);
                other.GetComponent<Character>().RemoveBrick();              
            }
        }
    }
}
