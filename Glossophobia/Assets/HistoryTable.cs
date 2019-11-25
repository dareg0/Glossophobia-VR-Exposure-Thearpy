using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryTable : MonoBehaviour
{

    public Transform entryContainer;
    public Transform entryTemplate;

    List<HistoryEntry> historyEntryList;
    List<Transform> historyEntryTransformList;

    public Transform savedData;
    List<string []> passedEntry;

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        passedEntry = new List<string []>();
        passedEntry = savedData.GetComponent<Controller>().records;

        historyEntryList = new List<HistoryEntry>();

        for (int i = 0; i < passedEntry.Count; i++)
        {
            historyEntryList.Add(new HistoryEntry { date = passedEntry[i][0], selfEval = passedEntry[i][1], timerOn = passedEntry[i][2], timerValue = passedEntry[i][3], audienceSize = passedEntry[i][4], reactionsOn = passedEntry[i][5], script = passedEntry[i][6] });
        }

        //string jsonString = PlayerPrefs.GetString("historyTable");
        //History history = JsonUtility.FromJson<History>(jsonString);

        historyEntryTransformList = new List<Transform>();

        foreach (HistoryEntry entry in historyEntryList)
        {
            CreateEntry(entry, entryContainer, historyEntryTransformList);
        }

        //History history = new History { historyEntryList = historyEntryList };
        //string json = JsonUtility.ToJson(history);
        //PlayerPrefs.SetString("historyTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("historyTable"));
    }

    void CreateEntry(HistoryEntry newEntry, Transform container, List<Transform> transformList)
    {
        float entrySpace = 80f;
       
        Transform historyEntry = Instantiate(entryTemplate, container);
        RectTransform historyEntryPos = historyEntry.GetComponent<RectTransform>();
        historyEntryPos.anchoredPosition = new Vector2(0, -entrySpace * transformList.Count);

        historyEntry.gameObject.SetActive(true);

        string date = newEntry.date;
        string selfEval = newEntry.selfEval;
        string timerOn = newEntry.timerOn;
        string timerValue = newEntry.timerValue;
        string audienceSize = newEntry.audienceSize;
        string reactionsOn = newEntry.reactionsOn;
        string script = newEntry.script;

        historyEntry.Find("Date").GetComponent<Text>().text = date;
        historyEntry.Find("SelfEval").GetComponent<Text>().text = selfEval;
        historyEntry.Find("TimerOn").GetComponent<Text>().text = timerOn;
        historyEntry.Find("TimerValue").GetComponent<Text>().text = timerValue;
        historyEntry.Find("AudienceSize").GetComponent<Text>().text = audienceSize;
        historyEntry.Find("ReactionsOn").GetComponent<Text>().text = reactionsOn;
        historyEntry.Find("Script").GetComponent<Text>().text = script;

        transformList.Add(historyEntry);
    }

    //private class History
    //{
    //    public List<HistoryEntry> historyEntryList;
    //}

    [System.Serializable]
    private class HistoryEntry
    {
        public string date;
        public string selfEval;
        public string timerOn;
        public string timerValue;
        public string audienceSize;
        public string reactionsOn;
        public string script;
    }

}
