using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AdvancedCustomizableSystem;

public class Tutorial1 : MonoBehaviour
{

    public CharacterCustomization characterCustomization;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    public void SetBodyForm(int i)
    {
        switch (i)
        {
            case 1:
                characterCustomization.SetBodyShape(BodyShapeType.Fat, slider1.value);
                break;
            case 2:
                characterCustomization.SetBodyShape(BodyShapeType.Thin, slider2.value);
                break;
            case 3:
                characterCustomization.SetBodyShape(BodyShapeType.Muscles, slider3.value);
                break;
        }
    }
}
