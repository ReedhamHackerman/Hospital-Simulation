using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource;
  

    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePatient();
        if (target == null)
        {
            return false;
        }
        resource = GWorld.Instance.RemoveCubicle();
        if (resource!=null)
        {
            inventory.addItems(resource);
        }
        else
        {
            GWorld.Instance.AddPatient(target);
            target = null;
            return false;
        }
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Waiting", -1);
        if (target!= null)
        {
            if (resource!=null)
            {
                target.GetComponent<GAgent>().inventory.addItems(resource);
            }
           
        }
        return true;
    }
}
