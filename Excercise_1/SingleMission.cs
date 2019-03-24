using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        //delegate of container
        private FunctionsContainer.myDelegate myDel;
        public event EventHandler<double> OnCalculate;
        public SingleMission(FunctionsContainer.myDelegate container, String name)
        {
            Name = name;
            myDel = container;
            Type = "Single";
        }
        
        public String Name { get; }
        public String Type { get; }

        //calculates the mission 
        public double Calculate(double value)
        {
            double myVal = this.myDel(value);
            //if not null - Raise the event
            OnCalculate?.Invoke(this, myVal);
            return myVal;
        }
    }
}