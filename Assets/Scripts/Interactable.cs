using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject InformationMenu;

    Transform player;

    void Start()
    {
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

  
}
