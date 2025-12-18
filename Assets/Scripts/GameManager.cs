using System.Collections;
using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public bool isActOne = false;
    public bool isActTwo = false;
    public bool isActThree = false;

    public ActOneCommander actOneCommander;
    
    public List<GameObject> listOne = new List<GameObject>();
    public List<GameObject> listTwo = new List<GameObject>();
    public List<GameObject> listThree = new List<GameObject>();


    public GameObject shawnOne;
    public GameObject shawnTwo;
    public GameObject shawnThree;
    
    
    public bool isShawnOne;
    public bool isShawnTwo;
    public bool isShawnThree;
    
    void Start()
    {
        ActivateListOne();
    }

    void Update()
    {
        
        
        
    }
    
    
    public void ActivateListOne()
    {
        SetActiveList(listOne);
    }

    public void ActivateListTwo()
    {
        SetActiveList(listTwo);
    }

    public void ActivateListThree()
    {
        SetActiveList(listThree);
    }

    void SetActiveList(List<GameObject> activeList)
    {
        SetListState(listOne, false);
        SetListState(listTwo, false);
        SetListState(listThree, false);

        SetListState(activeList, true);
    }

    void SetListState(List<GameObject> list, bool state)
    {
        foreach (GameObject go in list)
        {
            if (go != null)
                go.SetActive(state);
        }
    }
    
    
    

    public void launchActOneDialogue()
    {
        actOneCommander.ActOneDialogue();
        
    }
    
    
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1f);
        isActOne = false; 
    }

    public void closeAct()
    {
        
            isActOne = false;
            isActTwo = false; 
            isActThree = false; 
                    
        
        
    }

    public void threeShawn()
    {
        
        
        isShawnOne = false;
        isShawnTwo = true;
        
        shawnOne.SetActive(false);
        shawnTwo.SetActive(false);
        shawnThree.SetActive(true);
        
    }
    
    
    
}
