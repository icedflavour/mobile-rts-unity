using UnityEngine;

public class Side : MonoBehaviour
{
    public PlayingSide mySide;

    public GameObject MyPlayer;

    private void Awake()
    {
        var Players = FindObjectsOfType<Player>();

        foreach (Player playerEntity in Players)
        {
            if (playerEntity.mySide == mySide)
            {
                MyPlayer = playerEntity.gameObject;
                Debug.Log("I have found player" + MyPlayer);
                break;
            }
        }
    }
}
