using UnityEngine;

public class Recruiting : MonoBehaviour
{
    private Player myPlayer;
    private Side mySide;
    private Transform myUnits;

    public void Start()
    {
        mySide = GetComponent<Side>();
        myPlayer = mySide.MyPlayer.GetComponent<Player>();
        myUnits = mySide.MyPlayer.GetComponent<Transform>().Find("Units");
    }

    public void CreateUnit(GameObject unitToCreate)
    {
        Instantiate(unitToCreate,myUnits);
    }
}
