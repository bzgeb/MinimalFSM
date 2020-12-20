using UnityEngine;

public class Example : MonoBehaviour
{
    Fsm _fsm;

    void Start()
    {
        _fsm = new Fsm();
        _fsm.Start(IdleState);
    }

    void Update()
    {
        _fsm.Update();
    }

    Fsm.FsmState IdleState(Fsm.Step step)
    {
        if (step == Fsm.Step.Enter)
        {
            //On Enter
            Debug.Log($"On ${nameof(IdleState)} Enter");
        }
        else if (step == Fsm.Step.Update)
        {
            //On Update
            Debug.Log($"On ${nameof(IdleState)} Update");

            // On A press transition to OtherState
            if (Input.GetKeyDown(KeyCode.A))
                return OtherState;
        }
        else if (step == Fsm.Step.Exit)
        {
            //On Exit
            Debug.Log($"On ${nameof(IdleState)} Exit");
        }

        return null;
    }

    Fsm.FsmState OtherState(Fsm.Step step)
    {
        if (step == Fsm.Step.Enter)
        {
            //On Enter
            Debug.Log($"On ${nameof(OtherState)} Enter");
        }
        else if (step == Fsm.Step.Update)
        {
            //On Update
            Debug.Log($"On ${nameof(OtherState)} Update");

            //On A press transition to IdleState
            if (Input.GetKeyDown(KeyCode.A))
                return IdleState;
        }
        else if (step == Fsm.Step.Exit)
        {
            //On Exit
            Debug.Log($"On ${nameof(OtherState)} Exit");
        }

        return null;
    }
}