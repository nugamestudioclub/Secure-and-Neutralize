using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolManager : MonoBehaviour
{
    Tool current_tool;

    List<Tool> tools = new List<Tool>();

    KeyCode UseItem = KeyCode.F;

    private void Start()
    {
        tools.Add(Tool.CreateInstance<FlashlightTool>(gameObject));

        current_tool = tools[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(UseItem))
        {
            current_tool.UseTool();
        }

        // TODO:
        // Input to cycle between tools IF MULTIPLE TOOLS ARE ADDED
    }


}
