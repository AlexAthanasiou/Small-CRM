using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface ILogger
    {
        void Log(string message);

        void Log(Exception exception);
    }
}


//Epilekste logger:
//1. Console Logger
//2. File Logger


//"2"

//Epilekste onoma arxeiou:
//"log2.txt"

//- Init FileLogger(onom arxeiou)
//- assign stin metavliti klasis Logger


