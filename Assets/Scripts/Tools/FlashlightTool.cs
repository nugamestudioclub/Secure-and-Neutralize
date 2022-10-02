using UnityEngine;
using System.Collections;

public class FlashlightTool : Tool
{
    bool tool_is_enabled = false;

    [SerializeField]
    float rate = 10f;

    IEnumerator process;

    protected override void Start()
    {
        SPRITE_NAME = "flashlight.png";
        PREFAB_NAME = "Flashlight.prefab";
        pickup_tag = "Battery";
        do_top_off = true;

        max_tool_value = 20;
        tool_value = 20;
        value_per_pickup = 4;

        base.Start();


        var cam = gameObject.GetComponentInChildren<Camera>();

        related_prefab = GameObject.Instantiate(related_prefab, cam.transform);

        InitTool();

        DisableLight();
    }

    protected override void InitTool()
    {
        process = IEDeincrement();

        if (tool_sprites != null && tool_value < tool_sprites.Length)
        {
            current_sprite = tool_sprites[tool_value];
        }
    }

    public override bool UseTool()
    {
        if (tool_is_enabled)
        {
            DisableLight();
        }

        else if (tool_value > 0)
        {
            EnableLight();

            return true;
        }

        return false;
    }

    void DisableLight()
    {
        related_prefab.SetActive(false);
        this.enabled = tool_is_enabled = false;

        StopCoroutine(process);
    }

    void EnableLight()
    {
        this.enabled = tool_is_enabled = true;
        related_prefab.SetActive(true);

        process = IEDeincrement();
        
        StartCoroutine(process);
    }

    IEnumerator IEDeincrement()
    {
        while (tool_value > 0)
        {
            tool_value -= 1;

            Debug.Log("tool value: " + tool_value);

            yield return new WaitForSeconds(rate);
        }

        DisableLight();
    }
}
