using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    // Start is called before the first frame update
    void Start()
    {
       transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;

    }
    public void UpdateText() 
    {

       transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
        
    }
    public void SelecOption() 
    {
        LevelManager.Instance.SetPlayerAnswer(OptionID);
    }
}
