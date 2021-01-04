using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedCustomizableSystem;

public class Tutorial3 : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    public void ChangeSkinColor()
    {
        characterCustomization.SetBodyColor(BodyColorPart.Skin, Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f));
    }

    public void ChangeHairColor()
    {
        characterCustomization.SetBodyColor(BodyColorPart.Hair, Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f));
    }

    public void ChangeEyeColor()
    {
        characterCustomization.SetBodyColor(BodyColorPart.Eye, Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f));
    }

    public void ChaneUPColor()
    {
        characterCustomization.SetBodyColor(BodyColorPart.Underpants, Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f));
    }
}
