using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedCustomizableSystem;

public class Tutorial6 : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    public void CombineMesh()
    {
        characterCustomization.BakeCharacter();
    }

    public void SmileEmotion()
    {
        characterCustomization.PlayEmotion("Smile", 2f);
    }

    public void PlayAnimation()
    {
        foreach(var animator in characterCustomization.GetAnimators())
        {
            animator.SetBool("walk", true);
        }
    }

    public void CreateInstance()
    {
        characterCustomization.CreateNewBakeInstantiate("NewCharacterInstance");
    }

    public void Randomizer()
    {
        characterCustomization.Randomize();
    }

    public void SaveToFile()
    {
        characterCustomization.SaveToFile();
    }

    public void LoadFromFile()
    {
        characterCustomization.LoadFromFile();
    }
}
