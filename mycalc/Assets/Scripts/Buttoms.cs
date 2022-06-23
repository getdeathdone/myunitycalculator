using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttoms : MonoBehaviour
{
    public string value;
    public string oper;
    
    public Calcu calcu;

    public void AppendValueToDisplay()
    {
        calcu.UpdateValue(value);  
    }

    public void AppendOperand()
    {
        calcu.UpdateOperand(oper);
    }

    public void AnswerResult()
    {   
        calcu.Answer();     
    }

    public void Clear()
    {   
        calcu.ButtonClear();       
    }


}
