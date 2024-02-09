using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameplay : MonoBehaviour
{
    public List<Text> numText;
    public List<int> numList;
    public int[] numListget;
    bool contime;
    public float starttime = 30;
    public Text textstarttime;
    [SerializeField] GameObject resetButton;
    public AudioSource soundwin,lose;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (contime)
        {
            starttime -= Time.deltaTime;
            textstarttime.text = Mathf.Round(starttime).ToString();
            if(starttime <= 0)
            {
                StartCoroutine(waitLose());
                IEnumerator waitLose()
                {
                    lose.Play();
                    loseText.SetActive(true);
                    contime = false;
                    yield return new WaitForSeconds(2f);
                    starttime = 30;
                    resetButton.SetActive(true);
                    ClearValues();
                }
                
            }
        }

    }

    public void RestartButton()
    {
        offertonume();
        contime = true;
        resetButton.SetActive(false);
    }
    void offertonume()
    {
        for(int i = 0; i < 9; i++) {
            int ran = Random.Range(1, 10);
            while (numList.Contains(ran))
                ran = Random.Range(1, 10);
            numList.Add(ran);
            //print(numList[i]);

        }
        for (int i = 0; i < numList.Count; i++)
        {
            numListget[i] = numList[i];
            numListget[9 + i] = numList[i];
            numListget[18 + i] = numList[i];
            numListget[27 + i] = numList[i];
        }
        getnum();

    }
    List<int> ramget = new List<int>(36);

    void getnum()

    {
        for (int i = 0; i < 36; i++)
        {
            int ran2 = Random.Range(0, 36);
            while (ramget.Contains(ran2))
                ran2 = Random.Range(0, 36);
            ramget.Add(ran2);
        }
        for (int i = 0; i < numListget.Length; i++)
        {
            for (int j = 0; j < numList.Count; j++)
            {
                if ((numListget[ramget[i]] - 1) == j)
                {
                    numText[i].text = numListget[i].ToString();

                }
            }
        }
    }
    List<Button> btn;
    
    public List<int> btn1;
    bool ise = true;
    int index_1, index_2;
    int stor;
    public Text bn1, bn2,sum;
    int countbtn;
    public GameObject wintext, loseText;
    public void btnnum(int n)
    {
        FindObjectOfType<audioScript>().onClick.Play();
        for(int i = 0;i < ramget.Count; i++)
        {
            if(n == ramget[i])
            {
                numText[n].color = Color.red;
                ise = !ise;
                btn1.Add(numListget[n]);
              //  print(numListget[n]);
                index_1 = n;
                if (ise)
                {

                    bn1.text = numListget[index_1].ToString();
                    bn2.text = numListget[index_2].ToString();
                    ise = true;
                    
                    if (btn1[0] + btn1[1]==10)
                    {
                        stor = numListget[index_1] + numListget[index_2];
                       
                        sum.text = stor.ToString();
                        stor = 0;
                       // print("true");
                        btn1.Clear();
                        //numText[index_1].color = Color.blue;
                        //numText[index_2].color = Color.blue;
                        numText[index_1].text = numText[index_2].text = "";
                        numListget[index_1] = numListget[index_2] = 0;
                        index_1 = index_2 = 0;

                        countbtn ++;
                        print("true: "+countbtn);
                        if(countbtn == 18)
                        {
                            FindObjectOfType<audioScript>().completed.Play();
                            StartCoroutine(wait());
                           IEnumerator wait()
                            {
                                soundwin.Play();
                                wintext.SetActive(true);
                                yield return new WaitForSeconds(2f);
                                contime = false;
                                starttime = 30;
                                resetButton.SetActive(true);
                                ClearValues();
                            }

                        }
                    }
                    else
                    {
                        stor = numListget[index_1] + numListget[index_2];
                        sum.text = stor.ToString();
                        
                        sum.text = stor.ToString();
                        print ("false");
                        btn1.Clear ();
                        numText[index_1].color = Color.black;
                        numText[index_2].color = Color.black;
                        index_1 = index_2 = 0;
                    }
                }
                else
                {
                    index_2 = n;
                }

               
            }
        }
    }

    private void ClearValues()
    {
        countbtn = 0;
        ramget.Clear();
        numList.Clear();
        for(int i = 0; i < numListget.Length; i++)
            numListget[i] = 0;
        for (int i = 0; i < numText.Count; i++)
        {
            numText[i].text = "";
            numText[i].color = Color.black;
        }
        bn1.text = bn2.text = sum.text = "0";
        wintext.SetActive(false);
        loseText.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("HOME");
    }
}
