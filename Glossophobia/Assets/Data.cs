using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    //private bool m_isConnected;
    //public bool IsConnected
    //{
    //    get
    //    {
    //        return m_isConnected;
    //    }

    //    set
    //    {
    //        m_isConnected = value;
    //    }
    //}


    public List<string []> entries;

    // Start is called before the first frame update
    void Awake()
    {
        entries = new List<string []>();

        entries.Add(new string[] { "11/1/2019", "2", "Yes", "01:00:30", "Small", "Yes", "Medium" });
        entries.Add(new string[] { "11/1/2019", "5", "Yes", "02:10:30", "Large", "Yes", "Easy" });
        entries.Add(new string[] { "11/1/2019", "4", "Yes", "01:15:05", "Empty", "No", "Medium" });

        Debug.Log("---------" + entries.Count);
    }
}
