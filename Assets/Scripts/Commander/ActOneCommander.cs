using System.Collections;
using UnityEngine;
using DialogueEditor;
using System.Collections.Generic;

public class ActOneCommander : MonoBehaviour
{
    public MouseComponent mouseComp;

    
    
    
    
    public void ActOneDialogue()
    {
        
       
      
        
        NPCConversation conversation = this.GetComponent<NPCConversation>();
        
        ConversationManager.Instance.StartConversation(conversation);
        
        
    }
}
