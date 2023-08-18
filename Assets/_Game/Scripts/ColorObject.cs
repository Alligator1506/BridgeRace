using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorType colorType;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }

}
