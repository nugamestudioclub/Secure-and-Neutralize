using UnityEngine;
using UnityEditor;
using System;

// RADAR IS NOT A TOOL
public abstract class Tool : MonoBehaviour
{
    [SerializeField]
    protected Sprite[] tool_sprites;

    protected Sprite current_sprite;

    // how much matches left? how much charge left?
    [SerializeField]
    protected int tool_value, max_tool_value, value_per_pickup;

    protected string SPRITE_NAME, PREFAB_NAME;

    protected bool do_top_off = false;

    public string pickup_tag;

    protected GameObject related_prefab;

    protected virtual void Start()
    {
        // TODO:
        // CHECK IF BACKSLASHES FOR ASSET PATH WORKS ON ALL SYSTEMS

        related_prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/" + PREFAB_NAME);

        var c = AssetDatabase.LoadAllAssetsAtPath("Assets/Images/ToolSprites/" + SPRITE_NAME);

        if (c.Length <= 0)
        {
            Debug.LogWarning("Filepath: Assets/Images/ToolSprites/" + SPRITE_NAME + " failed to load. " +
                "Are you missing the sprite?");

            tool_sprites = new Sprite[1] { null };

            return;
        }

        tool_sprites = new Sprite[c.Length - 1]; // -1 bc of the null asset

        int skip = 0;

        for (int i = 0; i < c.Length; i++)
        {
            var cache = c[i] as Sprite;

            if (cache == null)
            {
                skip = -1;
                continue;
            }

            tool_sprites[i + skip] = cache;
        }

        // in case the sprites load not in order
        Array.Sort(tool_sprites, new Comparison<Sprite>((i1, i2) => i1.name.CompareTo(i2.name)));
    }

    /// <summary>
    /// Adds a Tool component to the GameObject target and intantiates it.
    /// Returns the component in case it is needed.
    /// ADD THE COMPONENT TO THE PLAYER!
    /// </summary>
    /// <param name="target"></param>
    /// <returns>Tool of type T</returns>
    public static T CreateInstance<T>(GameObject target) where T : Tool
    {
        var instance = target.AddComponent<T>();

        return instance;
    }

    protected virtual void InitTool()
    {
        tool_value = 0;

        if (tool_sprites != null && tool_value < tool_sprites.Length)
        {
            current_sprite = tool_sprites[tool_value];
        }
    }

    // Use function.
    // returns true if the tool was used, false if not.
    // this allows for a "failed to use" animation
    public virtual bool UseTool()
    {
        if ((tool_value -= 1) >= 0)
        {
            // pass

            return true;
        }

        tool_value = 0;

        return false;
    }

    // SetToolValue function
    // returns true if value_per_pickup would set the value to above
    // the maximum. use this for if we want to prevent getting
    // too much of something, like too many matches or batteries.
    //
    // if do_top_off is true, returns true but sets tool_value to the
    // highest it can go, not higher. Use this if you want the consumable
    // to be used, but for the extra value to be lost.
    // if you dont want it to be used, leave do_top_off as false. That way
    // you wont pick up the consumable if you cant "fit" it.
    // TODO: rework this to use Mathf.Clamp so it's actually readable.
    public virtual bool SetToolValue()
    {
        if (value_per_pickup > max_tool_value)
        {
            if (do_top_off)
            {
                tool_value = max_tool_value;
            }

            return do_top_off;
        }

        else
        {
            tool_value = (value_per_pickup < 0) ? 0 : value_per_pickup;
        }

        return true;
    }

    public virtual Sprite GetCurrentSprite()
    {
        return current_sprite;
    }
}
