using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    #region SingleTon
    /* SingleTon */
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(UIManager)) as UIManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "UIManager";
                    instance = container.AddComponent(typeof(UIManager)) as UIManager;
                }
            }

            return instance;
        }
    }
    #endregion

    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI talkText;
    private Text teststes;
    [SerializeField] private GameObject scanObject;

    public bool isAction;
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
