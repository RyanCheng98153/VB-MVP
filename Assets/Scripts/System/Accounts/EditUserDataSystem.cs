using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditUserDataSystem : MonoBehaviour
{
    [SerializeField] private GameObject _EditUserDataCanvas;
    [SerializeField] private TMP_InputField _NicknameInputfield;
    [SerializeField] private TMP_InputField _IDInputsystem;
    [SerializeField] private Toggle _MaleToggle;
    [SerializeField] private Toggle _FemaleToggle;
    [SerializeField] private TMP_Dropdown _HeaderDropdown;
    [SerializeField] private TMP_Dropdown _MonthDropdown;
    [SerializeField] private TMP_Dropdown _DayDropdown;
    [SerializeField] private TMP_Dropdown _YearDropdown;
    [SerializeField] private Button _ConfirmedButton;

    [SerializeField] private CurrentAccountDatas _CurrentAccountDatas;
    private UserData _UserData = new UserData();

    public void Start()
    {
        PopulateDropdowns();
        _EditUserDataCanvas.SetActive(false);
        this.enabled = false;
    }

    public void Awake()
    {
        // _UserData.account = account;
        // _UserData.password = password;

        _EditUserDataCanvas.SetActive(true);
        this.enabled = true;

        _NicknameInputfield.onValueChanged.AddListener(delegate { _UserData.Nickname = _NicknameInputfield.text; return; });
        _IDInputsystem.onValueChanged.AddListener(delegate { _UserData.UserID = _IDInputsystem.text; return; });

        _MaleToggle.onValueChanged.AddListener(delegate { if (_MaleToggle.isOn) { _UserData.Sex = "Male"; } });
        _FemaleToggle.onValueChanged.AddListener(delegate { if (_FemaleToggle.isOn) { _UserData.Sex = "Female"; } });

        _YearDropdown.onValueChanged.AddListener(delegate { _UserData.Year = int.Parse(_YearDropdown.options[_YearDropdown.value].text); return; });
        _MonthDropdown.onValueChanged.AddListener(delegate { _UserData.Month = _MonthDropdown.value; OnMonthValueChanged(); return; });
        _DayDropdown.onValueChanged.AddListener(delegate { _UserData.Day = _DayDropdown.value; return; });

        _ConfirmedButton.onClick.AddListener(delegate
        {
            ConfirmUserData();
            _CurrentAccountDatas.updateAccountDatas(_UserData);
            return;
        });
        
    }

    private void ConfirmUserData()
    {
        string mail = _CurrentAccountDatas.get_Mail();
    }


    private void PopulateDropdowns()
    {
        // Clear existing options
        _MonthDropdown.ClearOptions();
        _DayDropdown.ClearOptions();
        _YearDropdown.ClearOptions();

        // Add default option
        List<string> defaultOption = new List<string>() { "Default" , "-"};
        _MonthDropdown.AddOptions(defaultOption);
        _DayDropdown.AddOptions(defaultOption);
        _YearDropdown.AddOptions(defaultOption);

        // Add months to month dropdown
        List<string> months = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        _MonthDropdown.AddOptions(months);

        // Add years to year dropdown (from 1900 to current year)
        List<string> years = new List<string>();
        int currentYear = System.DateTime.Now.Year;
        for (int i = 1900; i <= currentYear; i++)
        {
            years.Add(i.ToString());
        }
        _YearDropdown.AddOptions(years);
    }

    public void OnMonthValueChanged()
    {
        // Get the selected month
        int selectedMonthIndex = _MonthDropdown.value;
        int selectedMonth = selectedMonthIndex + 1; // Months are zero-indexed in Unity

        // Get the selected year

        int selectedYear = 0;
        if(_YearDropdown.options[_YearDropdown.value].text != "Default")
            selectedYear = int.Parse(_YearDropdown.options[_YearDropdown.value].text);

        // Determine the number of days in the selected month
        int daysInMonth;
        switch (selectedMonth)
        {
            case 0:
                daysInMonth = 0;
                break;
            case 2:
                daysInMonth = IsLeapYear(selectedYear) ? 29 : 28;
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                daysInMonth = 30;
                break;
            default:
                daysInMonth = 31;
                break;
        }

        // Update the day dropdown with the correct number of days
        List<string> days = new List<string>();
        for (int i = 1; i <= daysInMonth; i++)
        {
            days.Add(i.ToString());
        }
        _DayDropdown.ClearOptions();
        _DayDropdown.AddOptions(days);
        _DayDropdown.value = 0;
    }

    private bool IsLeapYear(int year)
    {
        if (year % 4 != 0)
            return false;
        if (year % 100 != 0)
            return true;
        if (year % 400 == 0)
            return true;
        return false;
    }
}
