using UnityEngine;

public class Side : MonoBehaviour
{
    public PlayingSide mySide;

    public GameObject MyPlayer;

    private MeshRenderer myRenderer;

    private Color Blue = new Color(35f / 255f, 80f / 255f, 200f / 255f);
    private Color Red = new Color(200f / 255f, 35f / 255f, 35f / 255f);
    
    private void Awake()
    {
        myRenderer = GetComponent<MeshRenderer>();

        switch (mySide)
        {
            case PlayingSide.PlayerOne:
                myRenderer.material.SetColor("_Color", Blue);
                break;
            case PlayingSide.PlayerTwo:
                myRenderer.material.SetColor("_Color", Red);
                break;
            default:
                break;
        }

        var Players = FindObjectsOfType<Player>();

        foreach (Player playerEntity in Players)
        {
            if (playerEntity.mySide == mySide)
            {
                MyPlayer = playerEntity.gameObject;
                break;
            }
        }
    }
}
