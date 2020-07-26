using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    public enum eDropDownItem
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Purple,
    }

    public Dropdown targetDropdown;
    public Image targetImage;

    private void Start()
    {
        // content image 색 설정
        //targetDropdown.options[0] 
        // sprite 에 접근할 떄는  색상 등을 변경할 수  없음..! 왜냐하면 sprite 자체가 파일을 참조하기때문에 파일의 색을 바꿀수는 없으니까..
        
    }
    public void OnValueChanged()
    {
        switch((eDropDownItem)targetDropdown.value)
        {
            case eDropDownItem.Red:
                targetImage.color = Color.red;
                Debug.Log(targetImage.color);
                break;
            case eDropDownItem.Orange:
                targetImage.color = new Color32(255, 69, 0, 255);
                Debug.Log(targetImage.color);
                break;
            case eDropDownItem.Yellow:
                targetImage.color = Color.yellow;
                Debug.Log(targetImage.color);
                break;
            case eDropDownItem.Green:
                targetImage.color = Color.green;
                Debug.Log(targetImage.color);
                break;
            case eDropDownItem.Blue:
                targetImage.color = Color.blue;
                Debug.Log(targetImage.color);
                break;
            case eDropDownItem.Indigo:
                targetImage.color = new Color32(75, 0, 130, 255);
                Debug.Log(targetImage.color);
                break;
            case eDropDownItem.Purple:
                targetImage.color = new Color32(128, 0, 128, 255);
                Debug.Log(targetImage.color);
                break;
        }

    }
}
