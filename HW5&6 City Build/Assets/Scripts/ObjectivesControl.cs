using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesControl : MonoBehaviour
{
    public GameObject targetObj, nextObj;
    private UIManager textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI = GameObject.FindWithTag("ui").GetComponent<UIManager>();
    }

    // Entered objective trigger
    void OnTriggerEnter(Collider other)
    {
        CheckNext();
        nextObj.SetActive(true);
        GetComponent<AudioSource>().Play();
        Invoke("DeactivateTrigger", 2);
    }

    // Deactivates target trigger
    void DeactivateTrigger()
    {
        targetObj.SetActive(false);
    }

    // Checks next destination & update objText
    void CheckNext()
    {
        switch (nextObj.name)
        {
            case "BankCapsule":
                textUI.UpdateObjectivesUI(1);
                break;
            case "StoreCapsule":
                textUI.UpdateObjectivesUI(2);
                break;
            case "FriendCapsule":
                textUI.UpdateObjectivesUI(3);
                break;
            case "HomeCapsule":
                textUI.UpdateObjectivesUI(4);
                break;
        }
    }
}
