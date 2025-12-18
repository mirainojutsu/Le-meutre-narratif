using UnityEngine;
using UnityEngine.Events;

public class AnimLauncher : MonoBehaviour
{
    public Animator animator;


    public UnityEvent TestOn;
    public UnityEvent TestOff;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TestOn.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TestOff.Invoke();

            
        }
    }

  public   void AnimatorTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
    
    
}
