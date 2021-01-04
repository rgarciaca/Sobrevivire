using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedCustomizableSystem;

public class Tutorial5 : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    public void ChangeHat()
    {
        characterCustomization.SetElementByIndex(ClothesPartType.Hat, Random.Range(0, characterCustomization.hatsPresets.Count - 1));
    }

    public void ChangeHair()
    {
        characterCustomization.SetHairByIndex(Random.Range(0, characterCustomization.hairPresets.Count - 1));
    }

    public void ChangeBeard()
    {
        characterCustomization.SetBeardByIndex(Random.Range(0, characterCustomization.beardPresets.Count - 1));
    }

    public void ChangeAccessory()
    {
        characterCustomization.SetElementByIndex(ClothesPartType.Accessory, Random.Range(0, characterCustomization.accessoryPresets.Count - 1));
    }

    public void ChangeShirt()
    {
        characterCustomization.SetElementByIndex(ClothesPartType.Shirt, Random.Range(0, characterCustomization.shirtsPresets.Count - 1));
    }

    public void ChangePants()
    {
        characterCustomization.SetElementByIndex(ClothesPartType.Pants, Random.Range(0, characterCustomization.pantsPresets.Count - 1));
    }

    public void ChangeShoes()
    {
        characterCustomization.SetElementByIndex(ClothesPartType.Shoes, Random.Range(0, characterCustomization.shoesPresets.Count - 1));
    }

    public void Randomizer()
    {
        characterCustomization.Randomize();
    }
}
