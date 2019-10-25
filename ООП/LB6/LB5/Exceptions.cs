using System;
using System.Collections.Generic;
using System.Text;

namespace LB5
{
    
    class AttackInputException : ArgumentException
    {
        public object wrongValue;
        public AttackInputException(string message, object wrVal) : base(message)
        {
            wrongValue = wrVal;
        }

    }
    class ZeroAttackInputException : AttackInputException
    { 
        public ZeroAttackInputException(string message, int wrVal) : base(message,wrVal)
        { }
    }
}
