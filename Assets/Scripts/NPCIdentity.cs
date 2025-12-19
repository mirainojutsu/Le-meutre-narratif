using UnityEngine;
using DialogueEditor;

public class NPCIdentity : MonoBehaviour
{
    public AnimLauncher anim;
    
    public string npcID;
    public bool hasAlreadyTalked;
    public GameObject InformationMenu;

    public GameManager gameManager;
    
    public int questionCount;
    
    
    Transform player;
    public bool registerThisDude;
    
    
    public bool isInteractable;
    public bool isBed;

    public bool isShawn;
    
    public bool actOneInteraction;


    public bool isCommandeer;

    public bool isTiroir;

    public bool isCassette;
    
    void Start()
    {
        hasAlreadyTalked = false;
        player = Camera.main.transform;

        anim = GetComponentInChildren<AnimLauncher>();
    }

    void Update()
    {
        if (InformationMenu != null && InformationMenu.activeSelf)
        {
            Vector3 direction = InformationMenu.transform.position - player.position;
            direction.y = 0f; // empêche l'inclinaison verticale

            InformationMenu.transform.rotation = Quaternion.LookRotation(direction);
        }


        if (isShawn)
        {
            if (ConversationManager.Instance.GetBool("question1") &&
                ConversationManager.Instance.GetBool("question2") &&
                ConversationManager.Instance.GetBool("question3") &&
                ConversationManager.Instance.GetBool("question4"))
            {
                    
                ConversationManager.Instance.SetBool("allDone", true);
            }
            
        }
        
        
        
        
        
    }

    public void secondDialogue()
    {
        ConversationManager.Instance.SetBool("hasTalkedOnce", true);
    }


    public void intCount()
    {
        questionCount++;
        

    }

    public void shawnOne()
    {
        gameManager.isShawnOne = true;

        
        
    }

    public void shawnTwo()
    {
        gameManager.isShawnTwo = true;
    }

    public void shawnThree()
    {
        gameManager.isShawnThree = true;
    }


    public void commanderInt()
    {
        
        gameManager.commanderCount++;
    }
    
    


}