using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;
        List<FunctionsContainer.myDelegate> myContainerlist;
        public ComposedMission(String name)
        {
            myContainerlist = new List<FunctionsContainer.myDelegate>();
            Name = name;
            Type = "Composed";
        }

        public String Name { get; }
        public String Type { get; }

        //calculates the valye by missions order
        public double Calculate(double value)
        {
            double result = value;
            foreach (FunctionsContainer.myDelegate i in myContainerlist)
            {
                result = i(result);
            }
            //if not null - Raise the event
            OnCalculate?.Invoke(this, result);
            return result;
        }

        //adds the function to the list
        public ComposedMission Add(FunctionsContainer.myDelegate x)
        {
            myContainerlist.Add(x);
            return this;
        }
    }
}