using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

                                                                                    //Debug.Log()
public class Calculator : MonoBehaviour
{
    public InputField textField;
    string viewText, tempText, operand, result, tempOper;
    byte click;
    double input_1, input_2;
    float inputFunction;
   

    bool isAnswer, isOperand ,isResultValue = false;

    public void UpdateValue(string newValue)
    {   
        
        ChangeAfterAnswerAddValue();
        
        viewText += newValue;
        textField.text = viewText.ToString();
        
        Debug.Log("viewText = " + viewText);
                
        if(isOperand==true)
        {
            tempText = tempText + newValue;
        }
    }

    public void UpdatePeriod()
    {   
        if((isOperand==false)&(viewText!=null))
        {   
            if ( System.Convert.ToDouble(viewText.ToString())-System.Convert.ToInt32(viewText.ToString()) == 0)
            {   
                ChangeAfterAnswerAddValue();     
                    
                viewText += ",";
                textField.text = viewText.ToString();                
            } 
        } else if((isOperand==true)&(tempText!=null))
            {   
                if ( System.Convert.ToDouble(tempText.ToString())-System.Convert.ToInt32(tempText.ToString()) == 0)
                {   
                tempText = tempText + ",";       
                viewText += ",";
                textField.text = viewText.ToString();
                }
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
            
             if(isResultValue == true)
            {
                inputFunction=float.Parse(result);
            } else 
            {    
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
            result = viewText = textField.text;
            isResultValue = true;
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


        click = 0;
        input_1 = input_2 = 0;
        
        result = viewText = textField.text;

        isAnswer = true;
        isOperand = false;
        isResultValue = true;
        
        }
    }

    public void ButtonBackspace() 
    {   
        ChangeAfterAnswerAddValue();

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
        textField.text = viewText.ToString();      
    }

    public void ButtonClear()
    {
        viewText = tempText = operand = result = tempOper = null;
        textField.text = "";

        click = 0;
        inputFunction = 0;
        input_1 = input_2 = 0;

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

    public void ChangeAfterAnswerAddValue()
    {
        if(isAnswer==true)
        {   
            tempText = operand = null;
            if(isResultValue==true)
                ChangeAfterAnswer();
        }
    }
}
