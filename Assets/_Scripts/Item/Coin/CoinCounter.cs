using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private double displayValue;

    public double value;
    public float spacing;

    public Sprite[] spriteDigits;

    // Update is called once per frame
    void Update()
    {
        if (displayValue != value)
        {
            string digits = value.ToString();
            SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
            int numRenderers = renderers.Length;

            if (numRenderers < digits.Length)
            {
                while (numRenderers < spriteDigits.Length)
                {
                    GameObject spr = new GameObject();
                    spr.AddComponent<SpriteRenderer>();
                    spr.transform.parent = transform;
                    spr.transform.localPosition =
                        new Vector3(numRenderers * spacing, 0.0f, 0.0f);
                    spr.layer = 12;

                    numRenderers += 1;
                }

                renderers = GetComponentsInChildren<SpriteRenderer>();
            }
            else if (numRenderers > digits.Length)
            {
                renderers[numRenderers - 1].sprite = null;

                numRenderers -= 1;
            }

            int renderIndex = 0;

            foreach (char digit in digits)
            {
                int spriteIndex = int.Parse(digit.ToString());

                renderers[renderIndex].sprite = spriteDigits[spriteIndex];

                renderIndex = +1;
            }

            displayValue = value;
        }
    }
}
