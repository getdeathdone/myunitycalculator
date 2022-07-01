using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

                                                                                    //Debug.Log()
public class Calculator : MonoBehaviour
{   
    public const double PositiveInfinity = 1.0 / 0.0;
    public const double NegativeInfinity = -1.0 / 0.0;

    public InputField textField;
    string viewText, tempText, operand, result, tempOper, tempValueOper;
    byte click;
    double input_1, input_2;
    float inputFunction;
   
    bool isAnswer, isOperand ,isResultValue, isWorkResult, isPeriodInt1, isPeriodInt2 = false;

    public void WorkingWithResults()
    {   
        if(isWorkResult==false)
            isWorkResult = true;
        else isWorkResult = false;

        Debug.Log("isWorkResult  = " + isWorkResult );
    }

    public void UpdateValue(string newValue)
    {   
        if ((System.Convert.ToDouble(result)==PositiveInfinity)^(System.Convert.ToDouble(result)==NegativeInfinity)^(double.IsNaN(System.Convert.ToDouble(result))))
            ButtonClear();

        if((isWorkResult==true)&(isAnswer==true))
            ChangeAfterAnswerAddValue();
        else if((isWorkResult==false)&(isAnswer==true))
            ButtonClear();      
        
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
            ChangeAfterAnswerAddValue();
            if ((isPeriodInt1==true)&(tempText==null))
                {
                    viewText = viewText.Replace(",", "");
                    isPeriodInt1 = false;
                }else if ((System.Convert.ToDouble(viewText.ToString())-System.Convert.ToInt32(viewText.ToString()) == 0)&(isPeriodInt1==false)&(tempText==null))
                {   
                    viewText += ",";
                    isPeriodInt1 = true; 
                } 
        } else if((isOperand==true)&(tempText!=null))
                {   
                if (isPeriodInt2==true)
                {   
                    tempText = tempText.Replace(",", "");
                    viewText = tempOper;
                    viewText += operand;
                    viewText += tempText;
                    isPeriodInt2 = false;
                } else if ((System.Convert.ToDouble(tempText.ToString())-System.Convert.ToInt32(tempText.ToString()) == 0)&(isPeriodInt2==false))
                {   
                    tempText = tempText + ",";       
                    viewText += ",";
                    isPeriodInt2 = true;
                }  
            }
            textField.text = viewText.ToString();

    }

    public void PlusMinus() 
    {   
        if(viewText!=null)
        {
            ChangeAfterAnswerAddValue();

            if(isOperand==false)
            {
                if(System.Convert.ToDouble(viewText.ToString())>0)
                {
                    viewText = viewText.Insert(0,"-");
                
                } else if (System.Convert.ToDouble(viewText.ToString())<0)
                {
                    viewText = viewText.Remove(0,1);
                }
            } else if ((isOperand == true)&(operand!="*")&(operand!="/"))
            {   
                viewText = tempOper;
                if (operand=="-")
                {
                    viewText += "+"; 
                    operand = "+";
                } else if(operand=="+")
                {
                    viewText += "-";
                    operand = "-";
                }
                viewText += tempText; 
            }
    
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
                    tempText = operand = tempValueOper = null;
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
                tempValueOper = newOperand;
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
                inputFunction = float.Parse(viewText);

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

            isAnswer = isResultValue = true;
            inputFunction=0;
            result = viewText = textField.text;
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

        if(tempValueOper!=null)
                UpdateOperand(tempValueOper);
            
        }
    }

    public void ButtonBackspace() 
    {   
        int lengthViewText = viewText.Length;
        if(lengthViewText  == 1){
            ButtonClear();
            Debug.Log("ButtonClear()");
        }

        if((viewText[lengthViewText-1]==',')&(tempText==null))
        {
            isPeriodInt1 = false;
            Debug.Log("isPeriodInt1 = false;");
        }
        
        if(tempText!=null)
        {   int lengthTempText = tempText.Length;
            if((tempText[lengthTempText-1]==',')&(isOperand==true))
                isPeriodInt2 = false;
            Debug.Log("isPeriodInt2 = false;");
        }
        


        if(viewText!=null)
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

            isAnswer = false;  
        }   
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
        isPeriodInt1 = isPeriodInt2 = false;
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
            int numberOfCommas = period_chek(viewText);

            if (numberOfCommas>0)
                isPeriodInt1 = true;
            else isPeriodInt1 = false;

            isPeriodInt2 = false;

            tempText = operand = null;
            if(isResultValue==true)
                ChangeAfterAnswer();
        }
    }

    public int period_chek(string searchstring)
    {
        int period_search = 0;
            for (int i = 0; i < searchstring.Length; i++)
            {
                if (searchstring[i] == ',') 
                {
                    period_search++;
                }
            }
        return period_search;
    }
}
