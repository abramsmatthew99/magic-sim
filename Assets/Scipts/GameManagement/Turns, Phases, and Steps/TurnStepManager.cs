using System.Collections.Generic;
using UnityEngine;

public class TurnStepManager : MonoBehaviour
{
    public TurnStep CurrentStep { get; private set; }

    private Queue<TurnStep> stepQueue = new Queue<TurnStep>();

    public delegate void StepChangedHandler(TurnStep newStep);
    public event StepChangedHandler OnStepChanged;

    public void InitializeStepQueue(List<TurnStep> steps)
    {
        stepQueue.Clear();
        foreach (var step in steps)
        {
            stepQueue.Enqueue(step);
        }
        if (stepQueue.Count > 0)
        {
            CurrentStep = stepQueue.Dequeue();
            OnStepChanged?.Invoke(CurrentStep);
        }
    }

    public void NextStep()
    {
        Debug.Log("Called NextStep");
        if (stepQueue.Count == 0)
        {
            CurrentStep = null; // No more steps
            return;
        }
        
        CurrentStep = stepQueue.Dequeue();
        OnStepChanged?.Invoke(CurrentStep);
    }

    public bool IsQueueEmpty()
    {
        return stepQueue.Count == 0;
    }
}
