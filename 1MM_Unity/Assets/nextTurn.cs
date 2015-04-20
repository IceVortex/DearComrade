using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class nextTurn : MonoBehaviour {

    public GameManagement g;

    public void next()
    {
        g.nextTurn();
    }
}
