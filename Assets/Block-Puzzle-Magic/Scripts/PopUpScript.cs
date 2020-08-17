using System.Collections;
using System.Collections.Generic;
using GreedyGame.Runtime;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public string UnitId;

    void OnMouseDown()
    {
        Debug.Log("open EngagementWindow");
        GreedyGameAgent.Instance.showEngagementWindow(UnitId);

    }

    public void Clickbutton()
    {
        Debug.Log("open EngagementWindow");
        GreedyGameAgent.Instance.showEngagementWindow(UnitId);
    }
}
