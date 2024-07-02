using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{

    [SerializeField]
    private List<Player> players;

    private Queue<Player> turnQueue = new Queue<Player>();

    public delegate void TurnChangedHandler(Player player);
    public event TurnChangedHandler OnTurnChanged;

    private TurnStateManager turnStateManager;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var player in players) {
            turnQueue.Enqueue(player);
        }
        turnStateManager = FindObjectOfType<TurnStateManager>();
        turnStateManager.OnTurnEnded += OnTurnEnded;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTurnEnded() {
        NextPlayer();
        Debug.Log($"It is now {turnQueue.Peek()}'s turn.");
       
    }

    //Moves on to the next player and adds the current player to the back of the queue
    public void NextPlayer() {

        var oldPlayer = turnQueue.Dequeue();
        Debug.Log($"{oldPlayer}'s turn ended.");
        turnQueue.Enqueue(oldPlayer);
        OnTurnChanged?.Invoke(turnQueue.Peek());
        Debug.Log($"{turnQueue.Peek()}'s turn ended.");

    }
}
