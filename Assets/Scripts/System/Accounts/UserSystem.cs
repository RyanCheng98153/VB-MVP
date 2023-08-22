using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSystem : MonoBehaviour
{
    [SerializeField] EditUserDataSystem _EditUserDataSystem;
    [SerializeField] CurrentAccountDatas _CurrentAccountDatas;
    [SerializeField] LoginSystem _LoginSystem;
    

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public void Awake()
    {
        this.enabled = true;
        //_EditUserDataSystem.Awake();

        if (!_CurrentAccountDatas.get_isComplete())
        {
            _EditUserDataSystem.Awake();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _LoginSystem.Logout();
        }
    }
}
