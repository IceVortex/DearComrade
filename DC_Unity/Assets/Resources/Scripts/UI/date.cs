using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class date : MonoBehaviour {

    public string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
    public int month = 4;
    public int year = 2015;
    public Text UIDate;
    public AResources resources;

    void Start()
    {
        //updateDate();
    }

    public void updateDate()
    {
        UIDate.text = "1st of " + months[month] + ", " + year.ToString() + " (Turn " + (resources.turnIndex + 2).ToString() + ")";
        GetComponent<Text>().text = "The 1st of " + months[month] + ", " + year.ToString();
        month++;
        if (month > 11)
        {
            month = 0;
            year++;
        }
    }


}
