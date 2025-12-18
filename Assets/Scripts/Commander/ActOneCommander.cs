using System.Collections;
using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;

public class ActOneCommander : MonoBehaviour
{
    public MouseComponent mouseComp;


    public GameObject bedDefault;
    public GameObject bedDialogue;


    void Start()
    {
        
        bedDialogue.SetActive(false);
        
    }
    
    
    public void ActOneDialogue()
    {
        
       // extinction des feux
      
       bedDialogue.SetActive(true);
       bedDefault.SetActive(false);
       
        NPCConversation conversation = this.GetComponent<NPCConversation>();
        
        ConversationManager.Instance.StartConversation(conversation);
        
        
        
        
    }
}
