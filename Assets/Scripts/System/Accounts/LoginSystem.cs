using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LoginSystem : MonoBehaviour
{
    // keys and values sample
    [SerializeField] private CurrentAccountDatas _CurrentAccountDatas;
    [SerializeField] private EditUserDataSystem _EditUserDataSystem;
    [SerializeField] private UserSystem _UserSystem;
    

    // Systems
    [SerializeField] private SignUpSystem _SignUpSystem;

    // Input UIs of Login Page
    [SerializeField] private GameObject _LoginPageCanvas;
    [SerializeField] private Button _LoginButton;
    [SerializeField] private TMP_InputField _AccountInput;
    [SerializeField] private TMP_InputField _PasswordInput;
    [SerializeField] private Button _HidePasswordButton;

    // Account Related UIs
    [SerializeField] private Button _SignUpButton;

    // Response UI's of Login Page
    [SerializeField] private TMP_Text _LoginMessage1;
    [SerializeField] private TMP_Text _LoginMessage2;

    // Other Function UIs

    // Selecting Interact UIs
    EventSystem system;
    [SerializeField] private Selectable _FirstInput;


    // Account and Password input
    private string _Account = "";
    private string _Password = "";

    // Login constraints
    private int _PasswordLeastLength = 6;
    private int _TryLimit = 3;


    public void Awake()
    {
        this.enabled = true;
        _LoginPageCanvas.SetActive(true);
        _LoginButton.onClick.AddListener(delegate{
            if (_Account != "" && _Password != ""){
                TryLogin();
            }
        });
        _AccountInput.onValueChanged.AddListener(delegate{
            _LoginMessage1.text = "";
            _Account = _AccountInput.text; 
        });

        _PasswordInput.onValueChanged.AddListener(delegate{
            _LoginMessage1.text = "";
            _Password = _PasswordInput.text; 
        });

        _SignUpButton.onClick.AddListener(delegate{
            _LoginPageCanvas.SetActive(false);
            _SignUpSystem.Awake();
            this.enabled = false;
        });

        // Change the Password text to Hidden or Shown message.
        _HidePasswordButton.onClick.AddListener(delegate{
            if (_PasswordInput.contentType == TMP_InputField.ContentType.Password)
            {
                //Debug.Log("Password~");
                _PasswordInput.contentType = TMP_InputField.ContentType.Standard;
            }
            else
            {
                //Debug.Log("Standard");
                _PasswordInput.contentType = TMP_InputField.ContentType.Password;
            }
            _PasswordInput.Select();
            return;
        });


        system = EventSystem.current;
        _FirstInput.Select();

        _LoginMessage1.text = _LoginMessage2.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // using tab and shift tab to select UIs

        if(Input.GetKey( KeyCode.LeftShift ) && Input.GetKeyDown(KeyCode.Tab) ) {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(previous != null)
            {
                previous.Select();
            }
        }else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
    }


    private void TryLogin()
    {
        if (_Account == "") _LoginMessage1.text = "Account should not be empty"; return;
        if (_Password == "") _LoginMessage2.text = "Password should not be empty"; return;
        
        // Maybe we won't need this showing information cause hacker can take advantage of this rule to get the access.
        //if (_Password.Length < 0 )
        //    _LoginMessage2.text = "Password should be at least " + _PasswordLeastLength + "letters. ";

        if ( _TryLimit <= 0 ){
            _LoginMessage1.text = "Out of login attempt limit!";
            _LoginMessage2.text = "Please try again after 3 mins.";
            return;
        }

        if ( getLoginStatus(ref _Account, ref _Password) == "unknown"){
            
            // Reset the account and password
            _AccountInput.text = _Account = "";
            _PasswordInput.text = _Password = "";

            _LoginMessage1.text = "Unknown Account or Password.";
            _LoginMessage2.text = _TryLimit + " trys left.";

            _TryLimit -= 1;

            return;
        }

        _CurrentAccountDatas.LoginAccount(ref _Account, ref _Password);

        if (getLoginStatus(ref _Account, ref _Password) == "user")
        {
            UserLogin();
            return;
        }

        _LoginPageCanvas.SetActive(false);
        this.enabled = false;

    }

    private string getLoginStatus(ref string account, ref string password)
    {

        if (/*There is an account in DataBase*/ true )
        {
            // Master key/value pair exists
            return "user";
        }

        return "unknown";

    }

    private void UserLogin()
    {
        // Login With User ID
        _LoginPageCanvas.SetActive (false);
        _LoginPageCanvas.gameObject.SetActive(false);
        _UserSystem.Awake();
        
        Debug.Log("Welcome back User");
    }

    public void Logout()
    {
        _CurrentAccountDatas.LogoutAccount();
        this.Awake();
    }

}
