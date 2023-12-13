using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool IsOpen = false;
    [SerializeField] private GameObject menu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch(IsOpen)
            {
                case true:
                  menu.SetActive(false);
                  StartCoroutine(SetMenuStatus(0));
                break;

                case false:
                  menu.SetActive(true);
                  StartCoroutine(SetMenuStatus(1));
                break;
            }
        }
    }

    IEnumerator SetMenuStatus(int i)
    {
        yield return new WaitForSeconds(.1f);
        switch(i)
        {
            case 0:
            IsOpen = false;
            break;

            case 1:
            IsOpen = true;
            break;
        }
    }

}
