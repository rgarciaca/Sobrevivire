using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AdvancedCustomizableSystem;

public class Tutorial2 : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    public void SetHeadSize()
    {
        characterCustomization.SetHeadSize(slider1.value);
    }

    public void SetHeadOffset()
    {
        characterCustomization.SetHeadOffset(slider2.value);
    }

    public void SetHeight()
    {
        characterCustomization.SetHeight(slider3.value);
    }
}
