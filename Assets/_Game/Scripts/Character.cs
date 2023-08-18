using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : ColorObject
{
    [SerializeField] private BackBrick brickPrefabs;
    [SerializeField] private GameObject brickHolder;
    [SerializeField] private LayerMask stairLayer;

    private List<BackBrick> createdBricks = new List<BackBrick>();

    public int BackBrickCount => createdBricks.Count;
    [HideInInspector] public Stage stage;

    public int BrickCount => createdBricks.Count;

    protected virtual void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        ChangeColor(colorType);
    }

    public ColorType GetCharacterColor()
    {
        return colorType;
    }

    public bool CanMove(Vector3 nextPoint)
    {
        bool isCanMove = true;
        RaycastHit hit;
        if (Physics.Raycast(nextPoint,Vector3.down, out hit, 2f, stairLayer)) 
        {
            StairBrick stair = hit.collider.GetComponent<StairBrick>();
            if (stair.colorType != colorType && createdBricks.Count > 0) 
            {
                stair.ChangeColor(colorType);
                RemoveBrick();
                stage.NewBrick(colorType);
            }

            if (stair.colorType != colorType && createdBricks.Count > 0)
            {
                isCanMove = false;
            }
        }
        return isCanMove;
    }

    public void AddBrick()
    {
        BackBrick newBrick = Instantiate(brickPrefabs, brickHolder.transform);
        newBrick.ChangeColor(colorType);
        newBrick.transform.localPosition = Vector3.up * 0.3f * createdBricks.Count;
        createdBricks.Add(newBrick);
    }

    public void RemoveBrick()
    {
        if (createdBricks.Count > 0)
        {
            BackBrick brickToRemove = createdBricks[createdBricks.Count - 1];
            createdBricks.RemoveAt(createdBricks.Count - 1);
            Destroy(brickToRemove.gameObject); 
            stage.NewBrick(colorType);
        }
    }

    public void ClearBrick()
    {
        for (int i = 0; i < createdBricks.Count; i++)
        {
            Destroy(createdBricks[i]);
        }
        createdBricks.Clear();
    }
}