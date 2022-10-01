using UnityEngine;
using UnityEditor;
using System;

public abstract class Tool : MonoBehaviour
{
    [SerializeField]
    Sprite[] tool_sprites;

    Sprite current_sprite;

    // how much matches left? how much charge left?
    [SerializeField]
    protected int tool_value;

    private void Start()
    {
        var c = AssetDatabase.LoadAllAssetsAtPath("Assets/Images/sprite_test.png");

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
    /// </summary>
    /// <param name="target"></param>
    /// <returns>Tool of type T</returns>
    public static T CreateInstance<T>(GameObject target) where T : Tool
    {
        var instance = target.AddComponent<T>();

        instance.InitTool();

        return instance;
    }

    // Use function.
    // returns true if the tool was used, false if not.
    // this allows for a "failed to use" animation
    public virtual bool UseTool()
    {
        if ((tool_value-=1) >= 0)
        {
            // pass

            return true;
        }

        return false;
    }

    protected virtual void InitTool()
    {
        tool_value = 0;

        current_sprite = GetCurrentSprite();
    }

    protected virtual Sprite GetCurrentSprite()
    {
        return tool_sprites[tool_value];
    }
}
