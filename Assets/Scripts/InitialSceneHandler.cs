using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitialSceneHandler : MonoBehaviour
{

    public string inputR;
    public string inputC;
    public GameObject inputRow;
    public GameObject inputColoumn;
    public GameObject CheckforRowValue;
    public GameObject CheckforColValue;

    public void Start()
    {
        
    }
    public void Update()
    {
        
    }
    public void OnStartButtonClicked()
    {
        inputR = inputRow.GetComponent<Text>().text;
        inputC = inputColoumn.GetComponent<Text>().text;
        if(int.Parse(inputR) < 2 || int.Parse(inputR) >10)
        {
            CheckforRowValue.GetComponent<Text>().text = "value range = 2 - 10";

        }
        if(int.Parse(inputC) < 2 || int.Parse(inputC) > 10)
        {
            CheckforColValue.GetComponent<Text>().text = "value range = 2 - 10";
        }
        if (int.Parse(inputC) >= 2 && int.Parse(inputC) <= 10 && int.Parse(inputR) >= 2 && int.Parse(inputR) <= 10)
        {
            Inputs.rowSize = int.Parse(inputC);
            Inputs.coloumnSize = int.Parse(inputR);
            SceneManager.LoadScene("GamePlay");
        }
    }
}
