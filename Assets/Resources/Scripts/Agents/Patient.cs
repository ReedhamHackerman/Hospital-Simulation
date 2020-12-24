using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("IsWaiting", 1, true);
        goals.Add(s1, 3);
        SubGoal s2 = new SubGoal("isTrated", 2, true);
        goals.Add(s2, 3);
    }

  
}
