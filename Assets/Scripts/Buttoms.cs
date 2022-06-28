using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttoms : MonoBehaviour
{
    public string value;
    public string oper;
    
    public Calculator calculator;

    public void AppendValueToDisplay()
    {   
        calculator.UpdateValue(value);
    }

    public void AppendOperand()
    {   
        calculator.UpdateOperand(oper);
    }
    public void UpdatePlusMinus()
    {   
        calculator.PlusMinus();
    }

    public void AppendPeriod()
    {   
        calculator.UpdatePeriod();
    }

    public void Function(string valuefunction)
    {
        calculator.FunctionValue(valuefunction);
    }

    public void AnswerResult()
    {   
        calculator.Answer();
    }

    public void Clear()
    {   
        calculator.ButtonClear();
    }

    public void ButtonBackspace()
    {   
        calculator.ButtonBackspace();
    }


}
