using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerChangeSkyColor : MonoBehaviour
{

    public Color colorStart = new Color(255f/255f, 0f, 172f/255f);
    public Color colorEnd = new Color(0f, 255f/255f, 46f/255f);
    private float duration = 5.0F;
    private float duration2 = 30.0F;
    public Material cubamapSky;
    private float lerp2 = 0F;


    // Update is called once per frame
    void Update()
    {
        if (duration2 >= 0F)
        {
            duration2 = duration2 - 0.05F;
            cubamapSky.SetColor("_TintColor", colorStart);
            RenderSettings.fogColor = colorStart;
        }
        else
        {
            if (duration >= 0.5F)
            {
                duration = duration - 0.03F;
                float lerp = Mathf.PingPong(Time.time, duration) / duration;
                cubamapSky.SetColor("_TintColor", Color.Lerp(colorStart, colorEnd, lerp));
                RenderSettings.fogColor = Color.Lerp(colorStart, colorEnd, lerp);
            }
            else if (duration < 0.5F && duration >= 0.1F)
            {
                duration = duration - 0.01F;
                cubamapSky.SetColor("_TintColor", colorEnd);
                RenderSettings.fogColor = colorEnd;
            }
            else if (lerp2 < 1F && duration < 0.1F)
            {
                lerp2 = lerp2 + 0.01F;
                cubamapSky.SetColor("_TintColor", Color.Lerp(colorEnd, colorStart, lerp2));
                RenderSettings.fogColor = Color.Lerp(colorEnd, colorStart, lerp2);
            }
            else
            {
                cubamapSky.SetColor("_TintColor", colorStart);
                RenderSettings.fogColor = colorStart;
            }
        }
    }
}
