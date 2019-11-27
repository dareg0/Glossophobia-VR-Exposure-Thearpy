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

    private bool isGameOn;

    private bool scriptEnabled;
    private bool timerEnabled;
    private bool reactionEnabled;

    public GameObject GameStateButton;

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

    private bool finishedSetup;

    public GameObject timerObject;

    public Dropdown dropdown;
    //public GameObject openmenu;
    //public GameObject initialmenu;
    //private List<Vector3> emojipositions = new List<Vector3>();
    private List<Vector3> emojipositions = new List<Vector3>();
    private bool emojichoice = true;
    int person = 4;


	//[todo]
	public GameObject emoji3;
	public int particleCount = 9;
	public float particleMinSize = 0.4f, particleMaxSize = 0.8f;
	public GameObject emoji1copy;
	public GameObject emoji2copy;
	private void Awake()
    {
        isGameOn = false;
        finishedSetup = false;

        // initial states
        currScriptStateInt = 1;             // easy script
        currScriptObj = script_file_easy;   // easy script
        currScriptIndex = -1;                // default
        scriptEnabled = true;               // script enabled
        timerEnabled = true;                // timer on

        scriptList = new List<string>();

        currAudienceStateInt = 1;           // low occupancy
        currAudienceStateObj = LowOccup;
        currAudienceStateObj.SetActive(true);

        reactionEnabled = true;
        records = new List<string[]>();
    }

    // Start is called before the first frame update
    void Start()
    {
        emojipositions.Add(new Vector3(-3.275f, 0.24f, 5.055f));
        emojipositions.Add(new Vector3(0.062f, -0.224f, 4.142f));
        emojipositions.Add(new Vector3(0.995f, -0.204f, 3.424f));
        emojipositions.Add(new Vector3(-3.34f, 1.004f, 6.068f));
        emojipositions.Add(new Vector3(-0.887f, 1.09f, 6.068f));
        emojipositions.Add(new Vector3(-3.27f, 0.23f, 5.059f));
        emojipositions.Add(new Vector3(-1.35f, -0.216f, 4.142f));
        emojipositions.Add(new Vector3(-0.49f, 1.09f, 6.068f));
        emojipositions.Add(new Vector3(3.2f, 0.29f, 5.059f));
        emojipositions.Add(new Vector3(1.47f, 0.23f, 5.059f));
        emojipositions.Add(new Vector3(0.05f, 0.32f, 5.059f));
        emojipositions.Add(new Vector3(4.13f, 1.01f, 6.068f));
        emojipositions.Add(new Vector3(4.18f, 0.25f, 5.059f));

        PopulateList();
        //usertalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOn)
        {
            ScriptReady();

            if (reactionEnabled)
            {
                randomEmoji();
            }
        }
        else
        {
            if (finishedSetup)
            {
                parseTextFile(currScriptObj);
            }
        }
    }

    public void ReadyPlayButton()
    {
        finishedSetup = true;
        GameStateButton.GetComponentInChildren<Text>().text = "Start Game";
    }

    public void GameButton()
    {
        if (!finishedSetup)
            return;

        isGameOn = !isGameOn;

        if (isGameOn)
        {
            timerObject.GetComponent<TimerScript>().SetRunningState(isGameOn);
            GameStateButton.GetComponentInChildren<Text>().text = "Pause";

        }
        else
        {
            GameStateButton.GetComponentInChildren<Text>().text = "Resume";
            timerObject.GetComponent<TimerScript>().SetRunningState(isGameOn);
        }

    }

    public void TimerButton(bool enable)
    {
        timerEnabled = enable;
        if (enable)
            timerObject.SetActive(true);
        else
            timerObject.SetActive(false);
    }

    public void ReactionButton(bool enabled)
    {
        if (enabled == true)
        {
            reactionEnabled = true;
        }
        else
        {
            reactionEnabled = false;
        }
    }

    void randomEmoji()
    {
        StartCoroutine(Emoji());
    }


    //[todo]
    IEnumerator Emoji()
    {
        while (isGameOn == true)
        {
            reactionEnabled = false;
            int randomNumber = Random.Range(4, 10);
            int randomNumber2 = Random.Range(1, 1000);
            int randomperson = Random.Range(0, 13);
            yield return new WaitForSeconds(randomNumber);
            if (randomNumber2 % 3 == 0)
            {
                emoji1.transform.position = emojipositions[randomperson];
                emoji1.SetActive(true);
                yield return new WaitForSeconds(1);
				Exploding1();
                emoji1.SetActive(false);
            }
            else if(randomNumber2%3 == 1)
            {
                emoji2.transform.position = emojipositions[randomperson];
                emoji2.SetActive(true);
                yield return new WaitForSeconds(1);
				Exploding2();
                emoji2.SetActive(false);
            }
            else
			{
				emoji3.transform.position = emojipositions[randomperson];
				emoji3.SetActive(true);
				StartCoroutine(Rotate(1.5f));
				//yield return new WaitForSeconds(1);
				emoji3.SetActive(false);
            }
        }
    }
    //[todo]
	void Exploding1()
	{
		for (int i = 0; i < particleCount; i++)
		{
			Instantiate(emoji1copy, emoji1.transform.position, Quaternion.identity);
			emoji1copy.transform.localScale = emoji1.transform.localScale * Random.Range(particleMinSize, particleMaxSize);
		}
	}

	//[todo]
	void Exploding2()
	{
		for (int i = 0; i < particleCount; i++)
		{
			Instantiate(emoji2copy, emoji2.transform.position, Quaternion.identity);
			emoji2copy.transform.localScale = emoji2.transform.localScale * Random.Range(particleMinSize, particleMaxSize);
		}
	}

	//[todo]
	IEnumerator Rotate(float duration)
	{
		//yield return new WaitForSeconds(5);
		float startRotation = emoji3.transform.eulerAngles.y;
		float endRotation = startRotation + 360.0f;
		float t = 0.0f;
		while (t < duration)
		{
			t += Time.deltaTime;
			float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
			emoji3.transform.eulerAngles = new Vector3(emoji3.transform.eulerAngles.x, yRotation, emoji3.transform.eulerAngles.z);
			yield return null;
		}
	}

	public void OnIncreaseAudienceButtonClicked()
    {
        if (currAudienceStateInt < 3)
            this.currAudienceStateInt += 1;
        AudienceStatusText();
    }

    public void OnDecreaseAudienceButtonClicked()
    {
        if (currAudienceStateInt > 0)
            this.currAudienceStateInt -= 1;
        AudienceStatusText();
    }

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

    public void OnIncreaseDifficultyButtonClicked()
    {
        if (currScriptStateInt < 3)
            this.currScriptStateInt += 1;
        ScriptStatusText();
    }

    public void OnDecreaseDifficultyButtonClicked()
    {
        if (currScriptStateInt > 0)
            this.currScriptStateInt -= 1;
        ScriptStatusText();
    }

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

            currScriptObj = null;   // clean up the current pointer
        }
    }

    void ScriptReady()
    {
        if (!isGameOn || scriptList == null)
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
                OnRecordMenu();
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two))  // B's pressed
        {
            currScriptIndex -= 1;
            if (currScriptIndex >= 0 && scriptList[currScriptIndex] != null)
                scriptText.text = scriptList[currScriptIndex];
        }
    }


    public void Dropdown_select(int index)
    {
        if (index == 0)
        {
            currScriptObj = null;
        }
        else if (index == 1)
        {
            currScriptObj = script_file_easy;
        }
        else if (index == 2)
        {
            currScriptObj = script_file_med;
        }
        else
        {
            currScriptObj = script_file_hard;
        }
    }

    void PopulateList()
    {
        List<string> names = new List<string>() { "No Script", "Easy Script", "Medium Script", "Hard Script" };
        dropdown.AddOptions(names);
    }

    public void OnSaveRecordButton()
    {
        // if the menus it relies on is not active
        if (!SaveRecordMenu.activeSelf)
            return;
        int timerInt = (timerEnabled) ? 1 : 0;
        int reactionInt = (reactionEnabled) ? 1 : 0;
        int scriptInt = (scriptEnabled) ? 1 : 0;
        if (scriptEnabled)
            scriptInt = currScriptStateInt;
        string timeStr = timerObject.GetComponent<TimerScript>().ElapsedTimeStr();
        // date, selfeval, timer[0, 1], timer time, audience size(0,1,2,3), reactions[0, 1], which subscript [no script, easy, medium, hard]
        records.Add(new string[] { System.DateTime.Now.ToString(), "1", timerInt.ToString(), timeStr, currAudienceStateInt.ToString(), reactionInt.ToString(), scriptInt.ToString() });

        UIResatrt();
    }

    public GameObject SaveRecordMenu;

    private void OnRecordMenu()
    {
        RestartGameLogics();
        SaveRecordMenu.SetActive(true);
    }

    private void RestartGameLogics()
    {
        isGameOn = false;
        finishedSetup = false;

        // [TODO] should initial states be last time saved?
        currScriptStateInt = 1;             // easy script
        currScriptObj = script_file_easy;   // easy script
        currScriptIndex = -1;                // default
        //scriptEnabled = true;               // script enabled
        //timerEnabled = true;                // timer on

        scriptList = new List<string>();

        //currAudienceStateInt = 1;           // low occupancy
        //currAudienceStateObj = LowOccup;
        //currAudienceStateObj.SetActive(true);

        // reset timer
        timerObject.GetComponent<TimerScript>().TimerReset();
    }

    private void UIResatrt()
    {
        GameStateButton.GetComponentInChildren<Text>().text = "Start Game";

    }

}
