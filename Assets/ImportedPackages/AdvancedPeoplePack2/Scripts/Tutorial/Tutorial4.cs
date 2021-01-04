using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AdvancedCustomizableSystem;

public class Tutorial4 : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    public void OpenMouth()
    {
        characterCustomization.SetFaceShape(FaceShapeType.Mouth_Open, slider1.value);
    }

    public void EyeSize()
    {
        characterCustomization.SetFaceShape(FaceShapeType.Eye_Size, slider2.value);
    }

    public void MouthSize()
    {
        characterCustomization.SetFaceShape(FaceShapeType.Mouth_Size, slider3.value);
    }
}
