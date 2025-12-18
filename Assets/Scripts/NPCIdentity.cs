using UnityEngine;
using DialogueEditor;

public class NPCIdentity : MonoBehaviour
{
    public string npcID;
    public bool hasAlreadyTalked;
    public GameObject InformationMenu;
    
    
    
    Transform player;
    public bool registerThisDude;
    
    
    public bool isInteractable;
    public bool isBed;
    
    
    
    public bool actOneInteraction;
    
    void Start()
    {
        hasAlreadyTalked = false;
        player = Camera.main.transform;
    }

    void Update()
    {
        if (InformationMenu != null && InformationMenu.activeSelf)
        {
            Vector3 direction = InformationMenu.transform.position - player.position;
            direction.y = 0f; // empêche l'inclinaison verticale

            InformationMenu.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void secondDialogue()
    {
        ConversationManager.Instance.SetBool("hasTalkedOnce", true);
    }


    
}