using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownQuality : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("QualityLevel"))
        {
            int ql = PlayerPrefs.GetInt("QualityLevel");
            if (ql != QualitySettings.GetQualityLevel())
                QualitySettings.SetQualityLevel(ql);
        }
        else
        {
            SaveQuality();
        }

        dropdown.SetValueWithoutNotify(QualitySettings.GetQualityLevel());

        dropdown.onValueChanged.AddListener(delegate
        {
            OnValueChanged(dropdown);
        });

        dropdown.options.Clear();
        string[] names = QualitySettings.names;
        dropdown.AddOptions(new List<string>(names));
    }

    void OnValueChanged(TMP_Dropdown dropdown)
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        SaveQuality();
    }

    void SaveQuality()
    {
        PlayerPrefs.SetInt("QualityLevel", QualitySettings.GetQualityLevel());
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    // void update()
    // {

    // }
}
