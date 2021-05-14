using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{

    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI talkText;
    private Text teststes;
    [SerializeField] private GameObject scanObject;
    public bool isAction;

    #region SingleTon
    /* SingleTon */
    private static TalkManager instance;
    public static TalkManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(TalkManager)) as TalkManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "TalkManager";
                    instance = container.AddComponent(typeof(TalkManager)) as TalkManager;
                }
            }

            return instance;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region SingleTon
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TalkAction(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
            textPanel.SetActive(false);

        }
        else
        {
            isAction = true;
            textPanel.SetActive(true);
            scanObject = scanObj;
            talkText.text = scanObject.GetComponent<B_Test>().Test;
            TMProUGUIDoText.DoText(talkText, 1.0f);
        }
    }
}
