using UnityEngine;

public class Example : MonoBehaviour
{
    Fsm _fsm;

    Fsm.State _idleState;
    Fsm.State _otherState;

    void Start()
    {
        _idleState = Fsm_IdleState;
        _otherState = Fsm_OtherState;
        
        _fsm = new Fsm();
        _fsm.Start(_idleState);
    }

    void Update()
    {
        _fsm.OnUpdate();
    }

    void Fsm_IdleState(Fsm fsm, Fsm.Step step, Fsm.State state)
    {
        if (step == Fsm.Step.Enter)
        {
            //On Enter
            Debug.Log($"On ${nameof(Fsm_IdleState)} Enter");
        }
        else if (step == Fsm.Step.Update)
        {
            //On Update
            Debug.Log($"On ${nameof(Fsm_IdleState)} Update");

            // On A press transition to OtherState
            if (Input.GetKeyDown(KeyCode.A))
                fsm.TransitionTo(_otherState);
        }
        else if (step == Fsm.Step.Exit)
        {
            //On Exit
            Debug.Log($"On ${nameof(Fsm_IdleState)} Exit");
        }
    }

    void Fsm_OtherState(Fsm fsm, Fsm.Step step, Fsm.State state)
    {
        if (step == Fsm.Step.Enter)
        {
            //On Enter
            Debug.Log($"On ${nameof(Fsm_OtherState)} Enter");
        }
        else if (step == Fsm.Step.Update)
        {
            //On Update
            Debug.Log($"On ${nameof(Fsm_OtherState)} Update");

            //On A press transition to IdleState
            if (Input.GetKeyDown(KeyCode.A))
                fsm.TransitionTo(_idleState);
        }
        else if (step == Fsm.Step.Exit)
        {
            //On Exit
            Debug.Log($"On ${nameof(Fsm_OtherState)} Exit");
        }
    }
}