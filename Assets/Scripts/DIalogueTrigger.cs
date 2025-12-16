using UnityEngine;
using DialogueEditor;


public class DIalogueTrigger : MonoBehaviour
{
    
    public NPCConversation Conversation;
    
    
    
    
    public float distance = 3f;
    public string targetTag = "Barrel";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    Conversation = hit.collider.gameObject.GetComponent<NPCConversation>;
                    DoSomething(hit.collider.gameObject);
                }
            }
        }
    }

    void DoSomething(GameObject obj)
    {
        ConversationManager.Instance.StartConversation(Conversation);
    }
    

}
