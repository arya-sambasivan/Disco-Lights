using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cellStatus
{
     SELECTED,
     ALIVE,
     HIGHLIGHTED,
     DEAD
};
public class GamePlayManager : MonoBehaviour
{

    public int gridSizeX = 3;
    public int gridSizeY = 3;
    [SerializeField] GameObject Cellprefab;
    [SerializeField] GameObject gridHolder;
    GameObject[ , ] gridArray;
    List<GameObject> deadCellList = new List<GameObject>();
    int Totalcount = 0;
    int noOfDeadGrids = 0;
    [SerializeField] GameObject gameEndUI;
    void Start()
    {
        ArrangeGrid();
        Totalcount = gridSizeX * gridSizeY;
    }

    // Update is called once per frame 
    void Update()
    {
        
    }
    private void ArrangeGrid()
    {
        gridArray = new GameObject[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                GameObject cell = GameObject.Instantiate(Cellprefab);


                float width = cell.GetComponent<SpriteRenderer>().bounds.size.x;
                float height = cell.GetComponent<SpriteRenderer>().bounds.size.y;
                Vector2 origin = new Vector2(0 - ((gridSizeX * width) / 2), 0 - ((gridSizeY * height) / 2));
                cell.transform.position = origin + new Vector2(width * i*1.05f, height * j*1.05f);
                cell.transform.parent = gridHolder.transform;
                gridArray[i,j] = cell;
                cell.GetComponent<CellHandler>().i = i;
                cell.GetComponent<CellHandler>().j = j;
                cell.GetComponent<CellHandler>().currentCelltatus = cellStatus.ALIVE;
            }
        }
    }

    public void CheckForReachableCells(int posX,int posY)
    {
        deadCellList.Add(gridArray[posX, posY]);
        int i = posX;
        int j = posY;
        i++;
        j++;
        while (i<gridSizeX && j<gridSizeY)
        {
            if(gridArray[i,j].GetComponent<CellHandler>().currentCelltatus == cellStatus.ALIVE)
            {
                gridArray[i, j].GetComponent<SpriteRenderer>().color = Color.green;
                gridArray[i, j].GetComponent<BoxCollider2D>().enabled = false;
                gridArray[i, j].GetComponent<CellHandler>().currentCelltatus = cellStatus.HIGHLIGHTED;
                deadCellList.Add(gridArray[i, j]);
            }
            else
            {
                break;
            }

            i++;
            j++;

        }
        i = posX;
        j = posY;
        i++;
        j--;
        while (i < gridSizeX && j >=0)
        {
            Debug.Log(i + " jkjkj " + j);
            if (gridArray[i, j].GetComponent<CellHandler>().currentCelltatus == cellStatus.ALIVE)
            {
                gridArray[i, j].GetComponent<SpriteRenderer>().color = Color.green;
                gridArray[i, j].GetComponent<BoxCollider2D>().enabled = false;
                gridArray[i, j].GetComponent<CellHandler>().currentCelltatus = cellStatus.HIGHLIGHTED;
                deadCellList.Add(gridArray[i, j]);
            }
            else
            {
                break;
            }

            i++;
            j--;

        }

         i = posX;
         j = posY;
         i--;
         j--;

         while (i >= 0  && j >= 0)
         {
             if (gridArray[i, j].GetComponent<CellHandler>().currentCelltatus == cellStatus.ALIVE)
             {
                 gridArray[i, j].GetComponent<SpriteRenderer>().color = Color.green;
                 gridArray[i, j].GetComponent<BoxCollider2D>().enabled = false;
                gridArray[i, j].GetComponent<CellHandler>().currentCelltatus = cellStatus.HIGHLIGHTED;
                deadCellList.Add(gridArray[i, j]);
            }
             else
             {
                 break;
             }

             i--;
             j--;

         }
         i = posX;
         j = posY;
         i--;
         j++;

         while (i >= 0 && j <gridSizeY)
         {
             if (gridArray[i, j].GetComponent<CellHandler>().currentCelltatus == cellStatus.ALIVE)
             {
                 gridArray[i, j].GetComponent<SpriteRenderer>().color = Color.green;
                 gridArray[i, j].GetComponent<BoxCollider2D>().enabled = false;
                gridArray[i, j].GetComponent<CellHandler>().currentCelltatus = cellStatus.HIGHLIGHTED;
                deadCellList.Add(gridArray[i, j]);
            }
             else
             {
                 break;
             }

             i--;
             j++;

         }

        StartCoroutine("updateDeadCells");
    }
   private IEnumerator updateDeadCells()
    {
        yield return new WaitForSeconds(1.0f);
        noOfDeadGrids += deadCellList.Count;
        foreach(GameObject obj in deadCellList)
        {
            obj.GetComponent<SpriteRenderer>().color = Color.red;
            obj.GetComponent<CellHandler>().currentCelltatus = cellStatus.DEAD;
        }
        deadCellList.RemoveRange(0, deadCellList.Count);
        checkforGameEnd();
        
    }

    private void checkforGameEnd()
    {
        if(noOfDeadGrids == (gridSizeX*gridSizeY))
        {
            gameEndUI.SetActive(true);
        }

    }
}
