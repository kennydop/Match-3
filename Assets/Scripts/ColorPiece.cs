using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour
{   public enum ColorType
    {
        RED, YELLOW, GREEN, BLUE, PURPLE, LIGHT_BLUE, ANY, COUNT
    }
    [System.Serializable]
    public struct ColorSprite 
    {
        public ColorType color;
        public Sprite sprite;
    }

    private ColorType color;
    public ColorType Color { get { return color; } set { SetColor(value); } }
    private SpriteRenderer sprite;
    public ColorSprite[] colorSprites;
    public Dictionary<ColorType, Sprite> colorSpriteDict;

    public int NumColors { get { return colorSprites.Length; } }

    private void Awake()
    {
        colorSpriteDict = new Dictionary<ColorType, Sprite>();
        sprite = GetComponent<SpriteRenderer>();
        for (int i = 0; i < colorSprites.Length; i++)
        {
            if (!colorSpriteDict.ContainsKey(colorSprites[i].color))
            {
                colorSpriteDict.Add(colorSprites[i].color, colorSprites[i].sprite);
            }
        }
    }

    public void SetColor(ColorType newColor)
    {
        color = newColor;
        if (colorSpriteDict.ContainsKey(newColor))
        {
            sprite.sprite = colorSpriteDict[newColor];
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
