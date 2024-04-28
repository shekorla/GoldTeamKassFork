
using UnityEngine;

public class GameActionInvokerBehavior : MonoBehaviour
{

    public GameAction targetAction;
    // extremely simple code to invoke a gameaction. mostly making this so I can call it in animations
    
    
    public void InvokeGameAction()
    {
        targetAction.RaiseAction();
        
    }
    
    // Upon 3 seconds of thinking, I realized this would be the much, MUCH smarter way to use this in animations. Too bad I already spaghetti'd the animations to use multple instances of the invoker. please, PLEASE use this, it's much better.
    public void InvokeSpecificAction(GameAction SpecificAction)
    {
        SpecificAction.RaiseAction();
    }
     
}
