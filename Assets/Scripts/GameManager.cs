using System.Collections;
using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject TextRepair;

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

    public int commanderCount;

    public GameObject tiroirOne;
    public GameObject tiroirTwo;
    public GameObject tiroirThree;

    public GameObject soeur;

    public GameObject cassetteOne;
    public GameObject cassetteTwo;

    public bool isLastCommander;

    public GameObject lastCommander;
    public GameObject presqueCommander;
    public GameObject Act2Commander;


    void Start()
    {
        TextRepair.SetActive(false);

        ActivateListOne();
        tiroirOne.SetActive(false);
        soeur.SetActive(false);
        lastCommander.SetActive(false);
    }

    void Update()
    {
        if (commanderCount >= 6 && isActTwo)
        {
            presqueCommander.SetActive(false);
            Act2Commander.SetActive(true);
        }
    }

    public void activateLastCommander()
    {
        presqueCommander.SetActive(false);
        lastCommander.SetActive(true);
    }


    public void switchToDestroyed()
    {
        cassetteOne.SetActive(false);
        cassetteTwo.SetActive(true);
    }


    public void showCassette()
    {
        tiroirOne.SetActive(false);
        tiroirTwo.SetActive(true);
        tiroirThree.SetActive(true);
    }


    public void commanderIncrease()
    {
        commanderCount++;

    
    }


    public void ActivateListOne()
    {
        isActOne = true;
        isActTwo = false;
        isActThree = false;

        SetActiveList(listOne);
    }

    public void ActivateListTwo()
    {
        isActOne = false;
        isActTwo = true;
        isActThree = false;

        SetActiveList(listTwo);
    }

    public void ActivateListThree()
    {
        isActOne = false;
        isActTwo = false;
        isActThree = true;
        SetActiveList(listThree);
    }


    public void Drawer()
    {
        lastCommander.SetActive(true);
        presqueCommander.SetActive(false);
        Act2Commander.SetActive(false);
        Debug.Log("LECACADEFESSE");
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