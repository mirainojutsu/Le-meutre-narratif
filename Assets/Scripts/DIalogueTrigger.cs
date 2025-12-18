using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class DIalogueTrigger : MonoBehaviour
{

    public GameManager gameManager;
    public ScreenFader screenFader;
    
    public float distance = 3f;
    public string targetTag = "Barrel";

    private HashSet<string> talkedNPCs = new HashSet<string>();
    private int requiredNPCs = 2;
    private bool eventTriggered = false;

    public GameObject commander;

    public bool isCommanderReady = false;

    void Start()
    {
        //commander.SetActive(false);
        
    }
    
    
    

    private void ConversationStart()
    {
        screenFader.FadeIn(1);
    }

    private void ConversationEnd()
        {
            screenFader.FadeOut(1);
        }  

    
    void Update()
    {
        // Curseur
        if (ConversationManager.Instance.IsConversationActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
                ConversationStart();
                
                
                //screenFader.FadeIn(2);
                
                ConversationManager.Instance.StartConversation(conversation);
                
                
                
                //screenFader.FadeOut(1);

                ConversationEnd();
                
            }
            
            if (conversation != null)
            {
                ConversationManager.Instance.StartConversation(conversation);

                if (lookedIdentity.hasAlreadyTalked)
                {
                    ConversationManager.Instance.SetBool("hasTalkedOnce", true);
                }

                if (isCommanderReady)
                {
                    ConversationManager.Instance.SetBool("isReadyToTalk", true);
                    
                }
                

                lookedIdentity.hasAlreadyTalked = true;
                RegisterNPC(lookedIdentity.npcID);
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
    
}