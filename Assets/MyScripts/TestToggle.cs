using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestToggle : MonoBehaviour
{

    TestResult result;

    enum TestResult
    {
        Create,
        Destroy,
        Edit
    }

    [SerializeField] Toggle toggle_A;
    [SerializeField] Toggle toggle_B;

    public void TryToggleTest(int index)
    {
        switch (index)
        {
            case 0:
                result = TestResult.Create;
                break;
            case 1:
                result = TestResult.Destroy;
                break;
            case 2:
                result = TestResult.Edit;
                break;
            default:
                break;
        }

        Debug.Log("Result: " + result);
    }

    public void SetTestResultToCreate()
    {

        if (toggle_A.isOn)
        {
            TryToggleTest(0);
        }

    }

    public void SetTestResultToDestroy()
    {

        if (toggle_B.isOn)
        {
            TryToggleTest(1);
        }

    }

}
