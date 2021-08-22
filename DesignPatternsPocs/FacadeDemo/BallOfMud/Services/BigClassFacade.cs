using System;
using System.Collections.Generic;
using System.Text;

namespace BallOfMud.Services
{
    public class BigClassFacade
    {
        private BigClass _bigClass;
        public BigClassFacade()
        {
            _bigClass = new BigClass();
        }

        public void SetValue(int value)
        {
            _bigClass.SetValueI(value);
        }
        public int GetValue()
        {
            return _bigClass.GetValueA();
        }
        public void IncrementValue()
        {
            _bigClass.IncrementI();
        }
        public void DecrementValue()
        {
            _bigClass.DecrememntI();
        }
    }
}
