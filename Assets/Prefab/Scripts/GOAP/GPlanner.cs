using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> states;
    public GAction action;
    public Node(Node parent,float cost , Dictionary<string,int> allstates,GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.states = new Dictionary<string, int>(allstates);
        this.action = action;
    }
}

public class GPlanner
{
    public Queue<GAction> plan(List<GAction> actions,Dictionary<string,int> goal,WorldStates states)
    {
        List<GAction> usableActions = new List<GAction>();
        foreach(GAction g in actions)
        {
            if(g.IsAchievable())
            {
                usableActions.Add(g);
            }
        }
        List<Node> leaves = new List<Node>();
        Node start = new Node(null,0, GWorld.Instance.GetWorld().GetStates(), null);
        bool success = BuildGraph(start, leaves, usableActions, goal);
        if(!success)
        {
            Debug.Log("No Plan");
            return null;
        }
        Node cheapest = null;
        foreach (Node leaf in leaves)
        {
            if(cheapest == null)
            {
                cheapest = leaf;
            }
            else
            {
                if(leaf.cost <cheapest.cost)
                {
                    cheapest = leaf;
                }
            }
        }

        List<GAction> result = new List<GAction>();
        Node n = cheapest;
        while(n != null)
        {
            if(n.action != null)
            {
                result.Insert(0, n.action);
            }
            n = n.parent;
        }
        Queue<GAction> queue = new Queue<GAction>();
        foreach (GAction a in result)
        {
            queue.Enqueue(a);
        }
        Debug.Log("The Plan is : ");
        foreach (GAction a in queue)
        {
            Debug.Log("Q: " + a.actionName);
        }
        return queue;
    }


    private bool BuildGraph(Node parent,List<Node> leaves,List<GAction> usableActions,Dictionary<string,int> goal)
    {
        bool foundPath = false;
        foreach (GAction action in usableActions)
        {
            if (action.IsAchievableGiven(parent.states))
            {
                Dictionary<string, int> currentStates = new Dictionary<string, int>(parent.states);
                foreach (KeyValuePair<string,int> effect in action.effects)
                {
                    if (!currentStates.ContainsKey(effect.Key))
                    {
                        currentStates.Add(effect.Key, effect.Value);
                    }
                }
                Node node = new Node(parent, parent.cost + action.cost, currentStates, action);
                if(GoalAchieved(goal,currentStates))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GAction> subset = ActionSubset(usableActions, action);
                    bool found = BuildGraph(node, leaves, subset, goal); ;
                    if (found)
                    {
                        foundPath = true;
                    }
                }
            }
        }
        return foundPath;
    }
    
    private bool GoalAchieved(Dictionary<string,int> goal,Dictionary<string,int> state)
    {
        foreach (KeyValuePair<string,int> g in goal)
        {
            if (!state.ContainsKey(g.Key))
            {
                return false;
            }
           
        }
        return true;
    }
    private List<GAction> ActionSubset(List<GAction> actions,GAction removeMe)
    {
        List<GAction> subset = new List<GAction>();
        foreach (GAction action in actions)
        {
            if (!action.Equals(removeMe))
            {
                subset.Add(action);
            }
        }
        return subset;
     }
    
}
   
