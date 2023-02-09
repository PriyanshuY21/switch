using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   public int timeLimit = 300;

   public int optimalTime = 120;

    public bool shouldTimer = true;

   float timer=0.0f;

   bool countTime=true;

   TextMeshProUGUI TimerText;


  public static Score instance;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

   void Update()
   {
        if(shouldTimer)
        {
            if(countTime) {
                timer+=Time.deltaTime;
                TimerText.text = "" + (int)(timeLimit-timer);
            }
        }
   }

    void Start()
    {
        if (shouldTimer)
        { 
            TimerText = GameObject.Find("Canvas").transform.Find("Timer Text").GetComponent<TextMeshProUGUI>();
            TimerText.text = "" + (int)(timeLimit - timer);
        }
   }

    public void SetData(int optimalTime, int timeLimit, bool hasTimer) {
        countTime = true;
        timer = 0;
        this.optimalTime = optimalTime;
        this.timeLimit = timeLimit;
        shouldTimer = hasTimer;
    }

   public int GetScore()
   {
    countTime=false;
    if(timer<optimalTime)
    {
        timer=optimalTime;
    }
    float score=100-(100*((timer-optimalTime)/(timeLimit-optimalTime)));
    return (int)score;
   }
}
