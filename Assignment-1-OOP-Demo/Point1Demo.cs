using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_OOP_Demo
{
    internal struct Point1Demo
    {
        //What You Can Write Inside The Struct Or Class
        // 1. Attributes[Fields] => Member Variable  
        #region Attributes
        public int x;
        public int y;
        #endregion

        // 2. Functions[Constructor, Getter Setter, Method]
        // Constructor
        // 1.name of constructor have the same name of class or struct
        // 2. no return 
        #region Constructor
        public Point1Demo()
        {
            x = 0; // paramter less constructor it is take all attribute and give it defult value
            y = 0;
        }
        public Point1Demo(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public Point1Demo(int numbers)
        {
            x = y = numbers;
        }
        public override string ToString()
        {
            return $"({x} {y})";
        }
        #endregion
        // 3. Properties[Full Property, Automatic Property, Indexer]
        // 4. Events
    }
}
