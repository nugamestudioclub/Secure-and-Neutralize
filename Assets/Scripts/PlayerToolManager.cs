using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolManager : MonoBehaviour
{
    //[HideInInspector]
    //public Tool current_tool;


    //List<Tool> tools = new List<Tool>();
    public TempFlashlightComponent flashlight;
    KeyCode UseItem = KeyCode.F;

    private void Start()
    {
        //tools.Add(Tool.CreateInstance<FlashlightTool>(gameObject));
        flashlight.Toggle();
        //current_tool = tools[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(UseItem))
        {
            // current_tool.UseTool();
            flashlight.Toggle();
            
        }

        // TODO:
        // Input to cycle between tools IF MULTIPLE TOOLS ARE ADDED
    }
    public bool ProcessPickup(string tag)
    {
        //foreach (Tool t in tools)
       // {
       //     if (t.pickup_tag == tag && t.SetToolValue())
        //    {
        //        return true;
       //     }
      //  }

        return false;
    }
}
