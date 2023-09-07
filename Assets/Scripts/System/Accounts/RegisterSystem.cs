using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class RegisterSystem : MonoBehaviour
{
    [SerializeField] private LoginSystem _LoginSystem;

    [SerializeField] private UserSystem _UserSystem;

    // === Welcome Page ===
    // Canvas
    [SerializeField] private GameObject _WelcomePageCanvas;

    // UI
    [SerializeField] private Button _ContinueButtom;


    // === SignUp Page ===
    // Canvas
    [SerializeField] private GameObject _RegisterPageCanvas;
    
    [SerializeField] private TMP_InputField _MailInput;
    [SerializeField] private TMP_InputField _PasswordInput;
    [SerializeField] private TMP_InputField _RepeatPasswordInput;
    
    [SerializeField] private Button _BackButton;
    [SerializeField] private Button _ConfirmButton;

    [SerializeField] private TMP_Text _MailMessage;
    [SerializeField] private TMP_Text _PasswordMessage;
    [SerializeField] private TMP_Text _ConfirmPasswordMessage;
    [SerializeField] private TMP_Text _CountDownMessage;

    // Selecting Interact UIs
    EventSystem system;
    [SerializeField] private Selectable _FirstInput;


    // Register Mail and Password input
    private string _Mail = "";
    private string _Password = "";

    public void Start()
    {
        _RegisterPageCanvas.SetActive(false);
        this.enabled = false;
    }


    public void Awake()
    {
        _RegisterPageCanvas.SetActive(true);
        this.enabled = true;

        _MailMessage.text = "";
        _PasswordMessage.text = "";
        _ConfirmPasswordMessage.text = "";

        _MailInput.onValueChanged.AddListener( delegate { _Mail = _MailInput.text; });
        _PasswordInput.onValueChanged.AddListener( delegate { _Password = _PasswordInput.text; });
        _PasswordInput.onEndEdit.AddListener(
            delegate {
                if (_Password.Length < 8)
                {
                    _PasswordMessage.text = "Password should be at least 8 letters";
                }
                else
                {
                    _PasswordMessage.text = "";
                }
            });
        _ConfirmButton.onClick.AddListener( delegate { TrySignUp(); return; } );
        _BackButton.onClick.AddListener( delegate
        {
            _RegisterPageCanvas.SetActive(false);
            _LoginSystem.Awake();
            this.enabled = false;
        });

        system = EventSystem.current;
        _FirstInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null)
            {
                previous.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
    }

    private void TrySignUp()
    {
        if( _Mail == "" ) { _MailMessage.text = "Mail should not be empty. "; }
        if (_Password == "") { _PasswordMessage.text = "Password should not be empty. "; }
        if (_Mail == "" || _Password == "") return;

        if ( IsAccountExisted( ref _Mail ) )
        {
            Debug.Log("The Account has been signed up.");
            _MailMessage.text = "The Account has been signed up.";
            return;
        }

        // if password is illegal
        /* if (_Password != "")
        {
            Debug.Log("Not in compliance with the rules.");
            _ConfirmPasswordMessage.text = "Not in compliance with the rules.";
            return;
        } */

        if ( _Password != _RepeatPasswordInput.text)
        {
            Debug.Log("Password and Confirmed Password are not the same.");
            _ConfirmPasswordMessage.text = "Password and Confirmed Password are not the same.";
            return;
        }
        
        
        Debug.Log("Create Account");
        CreateAccount(ref _Mail, ref _Password);
        
        _RegisterPageCanvas.SetActive(false);

        _LoginSystem.Awake();
        this.enabled = false;
        return;
        
    }

    private bool IsAccountExisted( ref string mail )
    {
            
        Debug.Log("mail in user");
        return true;

        Debug.Log("Key not found");
        return false;
    }

    private void CreateAccount ( ref string mail, ref string password )
    {
        
    }
}
