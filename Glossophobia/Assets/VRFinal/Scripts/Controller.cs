using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // Four States Prefab - referenced to predefined gameobjects - will be activated according to user input
    public GameObject FullyOccup;
    public GameObject MedOccup;
    public GameObject LowOccup;
    public GameObject EmptyOccup;

    // Player records - later parsed int an UI board
    public List<string[]> records;

    public Text debugText;

    private int currAudienceStateInt;
    private GameObject currAudienceStateObj;    // reference pointer for the current active audience object

    private bool scriptEnabled;
    private bool timerEnabled;
    private bool reactionEnabled;

    public GameObject scriptButton;

    // Three difficulty levels of script files - referenced to built-in textfiles
    private int currScriptStateInt;
    private TextAsset currScriptObj;
    public TextAsset script_file_easy;
    public TextAsset script_file_med;
    public TextAsset script_file_hard;

    private List<string> scriptList;
    private int currScriptIndex;

    public GameObject emoji1;
    public GameObject emoji2;

    private bool finishedSetup;    // [TODO] when user finishes the setup, should be flagged true

    public GameObject timerObject;
    public Dropdown dropdown;
    public GameObject openmenu;
    public GameObject initialmenu;
    private void Awake()
    {
        finishedSetup = false;

        // initial states
        currScriptStateInt = 1;             // easy script
        currScriptObj = script_file_easy;   // easy script
        currScriptIndex = 0;                // first line
        scriptEnabled = true;               // script enabled
        timerEnabled = false;                // timer on

        scriptList = new List<string>();

        currAudienceStateInt = 1;           // low occupancy
        currAudienceStateObj = LowOccup;
        currAudienceStateObj.SetActive(true);

        reactionEnabled = false;
        records = new List<string[]>();
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (finishedSetup)
        {
            if (currScriptObj != null)
                parseTextFile(currScriptObj);
            ScrollScript();
            if (reactionEnabled)
                randomEmoji();

        }
    }

    //[TODO] should be referenced to somewhere on menu that toggles the script on and off
    void ScriptButton()
    {
        scriptEnabled = !scriptEnabled;

        if (scriptEnabled)
            scriptButton.GetComponentInChildren<Text>().text = "Pause Script";
        else
            scriptButton.GetComponentInChildren<Text>().text = "Resume Script";
    }

    //to check
    //[TODO] should be referenced to somewhere on menu that toggles the timer on and off
    public void TimerButton(bool enable)
    {
        timerEnabled = enable;
        if (enable)
            timerObject.SetActive(true);
        else
            timerObject.SetActive(false);
    }

    //to check
    //[TODO] should be referenced to somewhere on menu that toggles the reactions on and off
    public void ReactionButton(bool enable)
    {
        reactionEnabled = enable;
            // [TODO] generate emojis randomly
    }

    //to check
    // [TODO] generate emojis randomly
    void randomEmoji()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))  // A's pressed
        {
            if (!emoji1.activeSelf && !emoji2.activeSelf)
                emoji1.SetActive(true);
            else if(emoji1.activeSelf && !emoji2.activeSelf)
                emoji2.SetActive(true);
            else
            {
                emoji1.SetActive(false);
                emoji2.SetActive(false);
            }
        }
        //else if (OVRInput.GetDown(OVRInput.Button.Two))  // B's pressed
    }

    //IEnumerator Emoji()
    //{
    //    yield return new WaitForSeconds(5);
    //    emoji1.SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    emoji1.SetActive(false);
    //    yield return new WaitForSeconds(5);
    //    emoji2.SetActive(true);
    //    yield return new WaitForSeconds(1);
    //    emoji2.SetActive(false);
    //}

    // [TODO] if menus has a slider or something to change the value, should put a listener to override the currAudienceStateInt value backend
    public void OnIncreaseAudienceButtonClicked()
    {
        if (currAudienceStateInt < 3)
            this.currAudienceStateInt += 1;
        AudienceStatusText();
    }

    // [TODO] if menus has a slider or something to change the value, should put a listener to override the currAudienceStateInt value backend
    public void OnDecreaseAudienceButtonClicked()
    {
        if (currAudienceStateInt > 0)
            this.currAudienceStateInt -= 1;
        AudienceStatusText();
    }

    // [TODO] if menus has a slider or something to change the value, should put a listener to override the currAudienceStateInt value backend
    public void AudienceStatusText()
    {
        // disable the current state
        currAudienceStateObj.SetActive(false);
        switch (currAudienceStateInt)
        {
            case 1:
                debugText.text = "Low Occupancy";
                currAudienceStateObj = LowOccup;
                break;
            case 2:
                debugText.text = "Medium Occupancy";
                currAudienceStateObj = MedOccup;
                break;
            case 3:
                debugText.text = "Fully Occupied";
                currAudienceStateObj = FullyOccup;
                break;
            case 0:
                debugText.text = "Empty";
                currAudienceStateObj = EmptyOccup;
                break;
        }
        currAudienceStateObj.SetActive(true);
    }
/*
    // [TODO] if menus has a slider or something to change the value, should put a listener to override the currScriptStateInt value backend
    public void OnIncreaseDifficultyButtonClicked()
    {
        if (currScriptStateInt < 3)
            this.currScriptStateInt += 1;
        ScriptStatusText();
    }

    // [TODO] if menus has a slider or something to change the value, should put a listener to override the currScriptStateInt value backend
    public void OnDecreaseDifficultyButtonClicked()
    {
        if (currScriptStateInt > 0)
            this.currScriptStateInt -= 1;
        ScriptStatusText();
    }

    // [TODO] if menus has a slider or something to change the value, should put a listener to override the currScriptStateInt value backend
    public void ScriptStatusText()
    {
        // disable the current state
        switch (currScriptStateInt)
        {
            case 1:
                debugText.text = "Easy Level Script";
                currScriptObj = script_file_easy;
                break;
            case 2:
                debugText.text = "Mid Level Script";
                currScriptObj = script_file_med;
                break;
            case 3:
                debugText.text = "Hard Level Script";
                currScriptObj = script_file_hard;
                break;
            case 0:
                debugText.text = "Empty";
                currScriptObj = null;
                break;
        }
    }
*/

    // to check
    public void Dropdown_select(int index)
    {
        if(index == 0)
        {
            currScriptObj = null;
        }
        else if(index == 1)
        {
            currScriptObj = script_file_easy;
        }
        else if(index == 2)
        {
            currScriptObj = script_file_med;
        }
        else
        {
            currScriptObj = script_file_hard;
        }
    }

    //to check
    public void on_open_menu()
    {
        initialmenu.SetActive(true);
        openmenu.SetActive(false);
        scriptButton.SetActive(false);
    }

    // to check
    public void on_close_menu()
    {
        initialmenu.SetActive(false);
        openmenu.SetActive(true);
        scriptButton.SetActive(true);
        finishedSetup = true;
    }

    void parseTextFile(TextAsset txt)
    {
        if (txt != null)
        {
            var arrayString = txt.text.Split('\n');
            foreach (var line in arrayString)
                scriptList.Add(line);
        }
    }

    void ScrollScript()
    {
        if (!scriptEnabled || scriptList == null)
            return;

        if (OVRInput.GetDown(OVRInput.Button.One))  // A's pressed
        {
            currScriptIndex += 1;
            if (scriptList[currScriptIndex] != null)
                debugText.text = scriptList[currScriptIndex];
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two))  // B's pressed
        {
            currScriptIndex -= 1;
            if (scriptList[currScriptIndex] != null)
                debugText.text = scriptList[currScriptIndex];
            else
                debugText.text = "[The End]";
        }
    }

    // [TODO] should be referenced to a button that prmopts to save the current record
    void saveRecord()
    {
        int timerInt = (timerEnabled) ? 1 : 0;
        int reactionInt = (reactionEnabled) ? 1 : 0;
        int scriptInt = (scriptEnabled) ? 1 : 0;
        string timeStr = timerObject.GetComponent<TimerScript>().finishedTime();
        // date, selfeval, timer[0, 1], timer time, audience size(0,1,2,3), reactions[0, 1], which subscript [no script, easy, medium, hard]
        records.Add(new string[] { System.DateTime.Now.ToString(), timerInt.ToString(), timeStr, currAudienceStateInt.ToString(), reactionInt.ToString(), currScriptStateInt.ToString()});
    }
}
