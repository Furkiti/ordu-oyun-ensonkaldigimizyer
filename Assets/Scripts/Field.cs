using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Material initialMat;

    public int woodCost = 20;
    private int currentWood;
    public TextMeshPro woodCostText;

    public GameObject[] childObjects;
    private int currentIndex = 0;

    [HideInInspector]public bool isBuildingDone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentWood = 0;
        woodCostText.text = currentWood.ToString() + "/"+ woodCost.ToString();
    }

    public void AddWood()
    {
        currentWood++;
        woodCostText.text = currentWood.ToString() + "/"+ woodCost.ToString();
        
        int buildRate = woodCost / childObjects.Length;
        

        if (currentWood % buildRate == 0)
        {
            //int random = Random.Range(0, childObjects.Length);
            childObjects[currentIndex].GetComponent<MeshRenderer>().material = initialMat;
            childObjects[currentIndex].GetComponent<Outline>().enabled = false;
            currentIndex++;
        }

        if (currentWood.Equals(woodCost))
        {
            isBuildingDone = true;
            GameManager.Instance.GameCompleted();
        }
    }
    
    
}
