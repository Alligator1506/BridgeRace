using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Brick : ColorObject
{
    [HideInInspector] public Stage stage;

    public void OnDespawn()
    {
        stage.RemoveBrick(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (other.GetComponent<Character>().colorType == colorType) 
            {
                Debug.Log("gg");
                ChangeColor(ColorType.None);
                OnDespawn();
                other.GetComponent<Character>().AddBrick();
            }
        }
    }
}
