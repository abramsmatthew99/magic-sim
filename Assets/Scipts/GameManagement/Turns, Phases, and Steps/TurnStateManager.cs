using System.Collections.Generic;
using UnityEngine;

public class TurnStateManager : MonoBehaviour
{
    public TurnPhase currentPhase { get; private set; }
    public TurnStep currentStep => stepManager.CurrentStep;


    //Turn Ended Event
    public delegate void TurnEndedHandler();
    public event TurnEndedHandler OnTurnEnded;

    public delegate void PhaseChangedHandler(TurnPhase newPhase);
    public event PhaseChangedHandler OnPhaseChanged;

    [SerializeField]
    private List<TurnPhase> phases;

    private Queue<TurnPhase> turnPhaseQueue = new Queue<TurnPhase>();
    private TurnStepManager stepManager;

    private void Start()
    {
        stepManager = GetComponent<TurnStepManager>();
        InitializePhaseQueue();
    }

    public void NextPhase()
    {
        Debug.Log("Called NextPhase");
        if (turnPhaseQueue.Count == 0) {
            InitializePhaseQueue();
            OnTurnEnded?.Invoke();
            return;
        }
        StartNextPhase();
    }

    public void NextStep()
    {
        stepManager.NextStep();
        if (stepManager.IsQueueEmpty()) 
        {
            NextPhase();
        }
    }

    private void StartNextPhase()
    {
        if (turnPhaseQueue.Count == 0) 
        {
            return;
        }

        currentPhase = turnPhaseQueue.Dequeue();
        OnPhaseChanged?.Invoke(currentPhase);

        stepManager.InitializeStepQueue(currentPhase.steps);
    }

    public void AddPhase(TurnPhase phase)
    {
        turnPhaseQueue.Enqueue(phase);
    }

    public void SkipPhase() 
    {
        if (turnPhaseQueue.Count > 0)
        {
            turnPhaseQueue.Dequeue();
        }
    }

    private void InitializePhaseQueue()
    {
        foreach (var phase in phases)
        {
            turnPhaseQueue.Enqueue(phase);
        }
    }
}
