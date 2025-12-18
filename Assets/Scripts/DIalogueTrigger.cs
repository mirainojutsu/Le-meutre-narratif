using System.Collections;
using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class DIalogueTrigger : MonoBehaviour
{

    public GameManager gameManager;
    public ScreenFader screenFader;
    public MouseComponent mouseComp;
    
    public float distance = 3f;
    public string targetTag = "Barrel";

    private HashSet<string> talkedNPCs = new HashSet<string>();
    private int requiredNPCs = 2;
    private bool eventTriggered = false;

    public GameObject commander;

    public bool isCommanderReady = false;

    public bool needScreenFade = false;
    
    
    public ActOneCommander actOneCommander;
    
    void Start()
    {
        //commander.SetActive(false);
        
    }
    
    
    private void OnEnable()
        {
            ConversationManager.OnConversationStarted += ConversationStart;
            ConversationManager.OnConversationEnded += ConversationEnd;
         }

    private void OnDisable()
        {
        ConversationManager.OnConversationStarted -= ConversationStart;
        ConversationManager.OnConversationEnded -= ConversationEnd;
        }


    private void ConversationStart()
    {

        if (needScreenFade)
        {
            screenFader.FadeIn(1);
            
        }
        
        
    }

    private void ConversationEnd()
        {
            
            if (needScreenFade)
            {
                screenFader.FadeOut(1);
                needScreenFade = false;
            }

            if (gameManager.isActOne)
            {
                gameManager.launchActOneDialogue();
                
                
            }
            
            
            gameManager.closeAct();
            
            
        }  

    
    void Update()
    {
        
        
        if (gameManager.isShawnOne == true)
        {
            gameManager.shawnOne.SetActive(false);
            gameManager.shawnTwo.SetActive(true);
            gameManager.shawnThree.SetActive(false);
                    
        }
                
        if (gameManager.isShawnTwo == true)
        {
            
            gameManager.shawnTwo.SetActive(false);
            gameManager.shawnThree.SetActive(true);
                    
        }
        
        
        
        // Curseur
        if (ConversationManager.Instance.IsConversationActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseComp.mouseSensitivity = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseComp.mouseSensitivity = 100f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            screenFader.FadeIn(1);
            

        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            screenFader.FadeOut(1);
            


        }
        
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        NPCIdentity lookedIdentity = null;
       

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                lookedIdentity = hit.collider.GetComponent<NPCIdentity>();
            }

            
            
        }

        // Gestion affichage InformationMenu
        if (lookedIdentity != null)
        {
            lookedIdentity.InformationMenu.SetActive(true);
        }

        DisableAllOtherInfoMenus(lookedIdentity);

        // Interaction
        if (Input.GetKeyDown(KeyCode.E) && lookedIdentity != null)
        {
            NPCConversation conversation =
                lookedIdentity.GetComponent<NPCConversation>();

            
            
            if ((lookedIdentity.isInteractable == true) && conversation != null)
            {
               
                
                
                needScreenFade = true;
                StartCoroutine(StartConversationDelayed(conversation, 0f));
                //ConversationManager.Instance.StartConversation(conversation);

                if (lookedIdentity.actOneInteraction == true && !ConversationManager.Instance.IsConversationActive)
                {
                    gameManager.isActOne = true;
                    
                    
                }
                

                return;

            }

            if (lookedIdentity.isBed == true)
            {
                screenFader.FadeIn(1);
                StartCoroutine(DelayFadeOut());
                gameManager.ActivateListTwo();
            }


            if (conversation != null)
            {
                ConversationManager.Instance.StartConversation(conversation);

                if (lookedIdentity.hasAlreadyTalked && lookedIdentity.questionCount >= 2)
                {
                    ConversationManager.Instance.SetBool("hasTalkedOnce", true);
                    ConversationManager.Instance.SetInt("count", 3);
                    
                } else if (lookedIdentity.hasAlreadyTalked)
                {
                    ConversationManager.Instance.SetBool("hasTalkedOnce", true);
                    
                }

                if (isCommanderReady)
                {
                    ConversationManager.Instance.SetBool("isReadyToTalk", true);
                    
                }

                
                

               

                lookedIdentity.hasAlreadyTalked = true;


                if (lookedIdentity.registerThisDude == true)
                {
                    RegisterNPC(lookedIdentity.npcID);
                    
                }
                
            }
        }
    }

    void RegisterNPC(string npcID)
    {
        if (eventTriggered) return;

        if (talkedNPCs.Add(npcID))
        {
            if (talkedNPCs.Count >= requiredNPCs)
            {
                eventTriggered = true;
                OnTenNPCsTalked();
            }
        }
    }

    void OnTenNPCsTalked()
    {
        Debug.Log("10 NPC distincts atteints");
        
        isCommanderReady = true; 
        
       
        
        
        
    }
    
    void OnConversationStateChanged(bool active)
    {
        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible  = active;
    }
    
    void DisableAllOtherInfoMenus(NPCIdentity exception)
    {
        NPCIdentity[] npcs = FindObjectsOfType<NPCIdentity>();

        foreach (var npc in npcs)
        {
            if (npc != exception)
            {
                npc.InformationMenu.SetActive(false);
            }
        }
    }
    
    
    IEnumerator StartConversationDelayed(NPCConversation conversation, float delay)
    {
        yield return new WaitForSeconds(delay);
        ConversationManager.Instance.StartConversation(conversation);
    }


    IEnumerator DelayFadeOut()
    {
        yield return new WaitForSeconds(2f);
        screenFader.FadeOut(1);
    }
    
}