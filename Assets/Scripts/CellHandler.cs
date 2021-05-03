using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHandler : MonoBehaviour
{
    public int i;
    public int j;
    public cellStatus currentCelltatus;
    GamePlayManager gamePlayManagerInstance;
    void Awake()
    {
        gamePlayManagerInstance = FindObjectOfType<GamePlayManager>();
    }

    public void OnMouseDown()
    {
        currentCelltatus = cellStatus.SELECTED;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        GetComponent<BoxCollider2D>().enabled = false;
        gamePlayManagerInstance.CheckForReachableCells(i, j);
    }
}
