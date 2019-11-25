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

    public Text scriptText;

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

    private void Awake()
    {
        finishedSetup = false;

        // initial states
        currScriptStateInt = 1;             // easy script
        currScriptObj = script_file_easy;   // easy script
        currScriptIndex = 0;                // first line
        scriptEnabled = true;               // script enabled
        timerEnabled = true;                // timer on

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
        if (currScriptObj != null)
        {
            parseTextFile(currScriptObj);
            currScriptObj = null;
        }
            
        ScrollScript();
    }

    //[TODO] should be referenced to somewhere on menu that toggles the script on and off
    public void ScriptButton()
    {
        scriptEnabled = !scriptEnabled;

        if (scriptEnabled)
            scriptButton.GetComponentInChildren<Text>().text = "Pause Script";
        else
            scriptButton.GetComponentInChildren<Text>().text = "Resume Script";
    }

    //[TODO] should be referenced to somewhere on menu that toggles the timer on and off
    public void TimerButton()
    {
        timerEnabled = !timerEnabled;

        if (timerEnabled)
            timerObject.SetActive(true);
        else
            timerObject.SetActive(false);
    }

    //[TODO] should be referenced to somewhere on menu that toggles the reactions on and off
    void ReactionButton()
    {
        reactionEnabled = !reactionEnabled;

        if (reactionEnabled)
        {
            // [TODO] generate emojis randomly
        }
    }

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
                scriptText.text = "Low Occupancy";
                currAudienceStateObj = LowOccup;
                break;
            case 2:
                scriptText.text = "Medium Occupancy";
                currAudienceStateObj = MedOccup;
                break;
            case 3:
                scriptText.text = "Fully Occupied";
                currAudienceStateObj = FullyOccup;
                break;
            case 0:
                scriptText.text = "Empty";
                currAudienceStateObj = EmptyOccup;
                break;
        }
        currAudienceStateObj.SetActive(true);
    }

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
                scriptText.text = "Easy Level Script";
                currScriptObj = script_file_easy;
                break;
            case 2:
                scriptText.text = "Mid Level Script";
                currScriptObj = script_file_med;
                break;
            case 3:
                scriptText.text = "Hard Level Script";
                currScriptObj = script_file_hard;
                break;
            case 0:
                scriptText.text = "Empty";
                currScriptObj = null;
                break;
        }
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
            if (currScriptIndex < scriptList.Count)
            {
                if (scriptList[currScriptIndex] != null)
                    scriptText.text = scriptList[currScriptIndex];
            }
            else
            {
                scriptText.text = "END";
                OnSaveRecordMenu();
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two))  // B's pressed
        {
            currScriptIndex -= 1;
            if(currScriptIndex >= 0 && scriptList[currScriptIndex] != null)
                scriptText.text = scriptList[currScriptIndex];
        }
    }

    IEnumerator EndScript()
    {
        yield return new WaitForSeconds(5);
        scriptText.text = "END";
        scriptEnabled = false;
        yield return new WaitForSeconds(1);
        OnSaveRecordMenu();
    }

    // [TODO] should be referenced to a button that prmopts to save the current record
    public void OnSaveButton()
    {
        int timerInt = (timerEnabled) ? 1 : 0;
        int reactionInt = (reactionEnabled) ? 1 : 0;
        int scriptInt = (scriptEnabled) ? 1 : 0;
        if (scriptEnabled)
            scriptInt = currScriptStateInt;
        string timeStr = timerObject.GetComponent<TimerScript>().finishedTime();
        // date, selfeval, timer[0, 1], timer time, audience size(0,1,2,3), reactions[0, 1], which subscript [no script, easy, medium, hard]
        records.Add(new string[] { System.DateTime.Now.ToString(), "1", timerInt.ToString(), timeStr, currAudienceStateInt.ToString(), reactionInt.ToString(), scriptInt.ToString()});
        OnCloseRecordMenu();
    }

    public GameObject SaveRecordMenu;

    private void OnSaveRecordMenu()
    {
        scriptText.text = "SAVE RECORD";
        SaveRecordMenu.SetActive(true);
    }

    public void OnCloseRecordMenu()
    {
        scriptText.text = "CLOSE MENU";
        SaveRecordMenu.SetActive(false);
    }
}
