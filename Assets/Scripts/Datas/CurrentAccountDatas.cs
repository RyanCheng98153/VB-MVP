using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAccountDatas : MonoBehaviour
{
    private UserData _UserData;

    // only show in test mode, should be delete in final version
    // =================

    const string _defaultString = "default";
    const int _defaultInt = 0;

    // Account Data
    [SerializeField] private string _Status = "Logout";
    [SerializeField] private string _Mail   = _defaultString;
    [SerializeField] private string _Password = _defaultString;

    // User Data
    [SerializeField] private string _Nickname   = _defaultString;
    [SerializeField] private string _Id = _defaultString;
    [SerializeField] private string _Sex    = _defaultString;
    [SerializeField] private int    _Header = _defaultInt;
    [SerializeField] private int    _Year   = _defaultInt;
    [SerializeField] private int    _Month  = _defaultInt;
    [SerializeField] private int _Day = _defaultInt;

    // Status
    [SerializeField] private bool   _isComplete = false;

    // ===================

    public string get_Mail()
    {
        return _Mail;
    }

    public bool get_isComplete()
    {
        return _isComplete;
    }

    public void LoginAccount( ref string account, ref string password )
    {
        _Status = "Login";
        _Mail = account;
        _Password = password;
    }

    public void LoginAccount( ref UserData userData )
    {
        _Status = "Login";
        _Mail = userData.Account;
        _Password = userData.Password;

        _Nickname = userData.Nickname;
        _Sex = userData.Sex;

        _Header = userData.Header;
        _Year = userData.Year;
        _Month = userData.Month;
        _Day = userData.Day;
        
        checkComplete();
    }

    public void LogoutAccount()
    {
        _UserData = null;

        _Status = "Logout";
        _Mail = _Password = _defaultString;

        _Nickname = _Sex = _Id = _defaultString;
        _Header = _Year = _Month = _Day = _defaultInt;
    }

    public void updateAccountDatas(UserData userData)
    {

        _Nickname = userData.Nickname;
        _Sex = userData.Sex;
        _Id = userData.UserID;

        _Header = userData.Header;
        _Year = userData.Year;
        _Month = userData.Month;
        _Day = userData.Day;
    }

    public void checkComplete()
    {
        _isComplete = true;
        if (_Nickname == _defaultString) { _isComplete = false; return; };
        if (_Id == _defaultString) { _isComplete = false; return; };
        if (_Sex == _defaultString) { _isComplete = false; return; };
        if (_Header == _defaultInt) { _isComplete = false; return; };
        if (_Year == _defaultInt) { _isComplete = false; return; };
        if (_Month == _defaultInt) { _isComplete = false; return; };
        if (_Day == _defaultInt) { _isComplete = false; return; };

    }
}
