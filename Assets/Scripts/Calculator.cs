using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

                                                                                    //Debug.Log()
public class Calculator : MonoBehaviour
{
    public InputField textField;
    string viewText, tempText, operand, result, tempOper, resultFunction;

    double input_1, input_2;
    float inputFunction;
    int click;

    bool isAnswer, isOperand ,isResultValue = false;

    public void UpdateValue(string newValue)
    {   
        
        if(isAnswer==true)
        {   
            tempText = operand = null;

            if(isResultValue==true)
                ChangeAfterAnswer();
        }
        
        viewText += newValue;
        textField.text = viewText.ToString();
        
        Debug.Log("viewText = " + viewText);

        resultFunction = null;
                
        if(isOperand)
        {
            tempText = tempText + newValue;
        }

    }

    public void UpdatePeriod()
    {   
        if ( System.Convert.ToDouble(viewText.ToString())-System.Convert.ToInt32(viewText.ToString()) == 0)
        {
            if(isResultValue==true)
                {
                    ChangeAfterAnswer();     
                }

            viewText += ",";
            textField.text = viewText.ToString();
        }
    }

    public void UpdateOperand(string newOperand)
    {   
        if(viewText!=null) 
        {   
            click++;      
                if(click == 1)
                {   
                    if((isAnswer==true)&(result!=null))
                    {   
                    tempText = operand = null;
                    input_1 = System.Convert.ToDouble(result.ToString());
                    viewText = result;
                    } else
                    {   
                    input_1 = System.Convert.ToDouble(viewText.ToString());
                    }

                tempOper = viewText;
                }

            if(isOperand == true)
            {
                viewText = tempOper;   
            } 

            viewText += newOperand; 
            textField.text = viewText.ToString();
            isAnswer = false;

            if((click > 1)&(tempText!=null))
            {   
                Answer();   
            }

            operand = newOperand;
            isOperand = true;
        } 
    }

    public void FunctionValue(string newFunction)
    {
        if((viewText!=null)&(isOperand==false))
        {   
            
            if (resultFunction != null)
            {   
                Debug.Log("resultFunction = " + resultFunction);
                inputFunction=float.Parse(resultFunction);
            } else if(isResultValue == true)
            {
                inputFunction=float.Parse(result);
            } else 
            {    
                Debug.Log("viewText = " + viewText);
                inputFunction=float.Parse(viewText);
            }

            if (newFunction == "x²")
            {
                textField.text = (Mathf.Pow(inputFunction, 2)).ToString();
            } else if (newFunction == "√")
            {   
                textField.text = (Mathf.Sqrt(inputFunction)).ToString();
            } else if (newFunction == "1/x")
            {   
                textField.text = (1/inputFunction).ToString();
            }

            inputFunction=0;
            viewText = textField.text;
            resultFunction = textField.text;

            isAnswer = false;
            isResultValue = false;

            Debug.Log("viewText = " + viewText);
        }
    }

    public void Answer()
    {   

        if((isAnswer==false)&(input_2==0)&(viewText!=null)&(isOperand==true)&(tempText!=null))
        {   
                
            input_2 = System.Convert.ToDouble(tempText.ToString());
        
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
        click = 0;
        
        result = viewText = textField.text;

        isAnswer = true;
        isOperand = false;
        isResultValue = true;
        
        }
    }

    public void ButtonBackspace() 
    {   
        if((isOperand==true)&(click==1)&(tempText==null))
        {
            isOperand = false;
            operand = null;
            click = 0;
        }

        if(isOperand)
        {
            tempText = tempText.Remove(tempText.Length - 1);
        }

        viewText = viewText.Remove(viewText.Length - 1);
        textField.text = viewText;      
    }

    public void ButtonClear()
    {
        resultFunction = viewText = tempText = operand = null;
        textField.text = "";

        click = 0;
        inputFunction=0;

        isAnswer = false;
        isOperand = false;
        isResultValue = false;
    }

    public void ChangeAfterAnswer()
    {
        textField.text = viewText = result;
        result = null;
        isResultValue = false;
    }
}
