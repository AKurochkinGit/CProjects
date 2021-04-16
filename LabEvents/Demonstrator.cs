using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEvents
{

    class Demonstrator
    {
        public Calculator calculator = new Calculator();

        public Demonstrator(int _restTime)
        {
            this.calculator.restTime = _restTime;
            this.stopCalculation += calculator.isWork; //когда вычисления прекращены вызывается isWork  с параметром false
            calculator.calculationFinished += this.Display;//подписываем вывод демонстратора на работу калькулятора
        }
        //передача форме результатов вычислений
        public delegate void DisplayThis(string text);
        public event DisplayThis display;
        public void Display(int _result, int bb, int ub)
        {
            if (_result != 0)
            {
                display?.Invoke("Максимальное странное число на интервале [" + bb.ToString() + ", " + ub.ToString() + "]: " + _result.ToString() + ".");
            }
            else
            {
                display?.Invoke("На интервале [" + bb.ToString() + ", " + ub.ToString() + "] нет странных чисел.");
            }
        }
        //передача калькулятору события завершения вычислений
        public delegate void StopCalculation(bool iw);
        public event StopCalculation stopCalculation;
        public void StopWork()
        {
            stopCalculation?.Invoke(false);
        }
    }
}
