using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calcu : MonoBehaviour
{
    public InputField textField;
    string viewText;
    string tempText;
    string operand;
    string result;

    int input_1;
    int input_2;

    bool isAnswer = false;
    bool isResultValue = false;
    bool isOperand = false;
    

    public void UpdateValue(string newValue)
    {   
        if(isAnswer==true)
            {   
                tempText = operand = null;

                if(isResultValue==true)
                {
                    textField.text = result;
                    viewText = result;
                    result = null;
                    isResultValue = false;
                    
                }   
                
                viewText += newValue;
                textField.text = viewText.ToString();
                
            } else
            {
                viewText += newValue;
                textField.text = viewText.ToString();
            }
                
        if(isOperand)
        {
            tempText = tempText + newValue;
        }

    }

    public void UpdateOperand(string newOperand)
    {   
        if((isOperand==false)&(viewText!=null)) 
        {   
                if((isAnswer==true)&(result!=null))
                {   
                    tempText = operand = null;
                    input_1 = System.Convert.ToInt32(result.ToString());
                    viewText = result;
                    
                } else
                {
                    input_1 = System.Convert.ToInt32(viewText.ToString());
                }
            
            viewText += newOperand;
            textField.text = viewText.ToString();
            isAnswer = false;

            operand = newOperand;
            isOperand = true;

        }
    }

    public void Answer()
    {   
        if((isAnswer==false)&(input_2==0)&(viewText!=null)&(isOperand==true)&(tempText!=null))
        {   
            input_2 = System.Convert.ToInt32(tempText.ToString());
        
            if(operand=="+")
            {
                textField.text = (input_1 + input_2).ToString();
                
            }else if(operand=="-")
            {
                textField.text = (input_1 - input_2).ToString();
                
            }else if(operand=="*")
            {
                textField.text = (input_1 * input_2).ToString();
                
            }else if(operand=="/")
            {
                textField.text = (input_1 / input_2).ToString();
            }

        input_1 = input_2 = 0;
        result = textField.text;

        isAnswer = true;
        isOperand = false;
        isResultValue = true;
        
        }
    }

    public void ButtonClear()
    {
        viewText = tempText = operand = null;
        textField.text = "";

        isAnswer = false;
        isOperand = false;
        isResultValue = false;

    }
}
