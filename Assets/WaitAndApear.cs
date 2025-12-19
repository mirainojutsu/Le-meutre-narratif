using UnityEngine;
using System.Collections;

public class WaitAndApear : MonoBehaviour
{
    public GameObject StartScreen;
    public float startDelay;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        StartCoroutine(Disapear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AppearFunctions(float time)
    {
        StartCoroutine(Appear(time));
    }

    IEnumerator Appear(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartScreen.SetActive(true);
        yield break;
    }
    
    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(startDelay);
        StartScreen.SetActive(false);
        yield break;
    }
}

