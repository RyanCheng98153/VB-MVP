using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    const string defaultString = "default";
    const int defaultInt = 0;
    public UserData(){
        
    }

    public UserData(    
        string account, string password
        
    ){
        this.UserID         = defaultString;
        
        this.Account    = account;
        this.Password   = password;

        this.Header     = defaultInt;

        this.Nickname   = defaultString;
        this.Sex        = defaultString;

        // BirthDay 
        this.Year       = defaultInt;
        this.Month      = defaultInt;
        this.Day        = defaultInt;

        this.FriendID         = defaultString;
    }

    enum SexCode
    {
        male = 0,
        female = 1,
        other = 2,
    };

    public string UserID { get; set; }
    public string Account { get; set; }
    public string Password { get; set; }

    public string Nickname { get; set; }
    public string Sex { get; set; }
    public int Header { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public string FriendID { get; set; }
}
