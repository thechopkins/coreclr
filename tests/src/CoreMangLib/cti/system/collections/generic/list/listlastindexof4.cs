// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;

/// <summary>
/// System.Collections.Generic.List.LastIndexOf(T item, Int32,Int32)
/// </summary>
public class ListLastIndexOf4
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        //TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;

        //TestLibrary.TestFramework.LogInformation("[Negative]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        retVal = NegTest3() && retVal;

        return retVal;
    }

    public class CustomIntIEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return x == y;
        }
        
        public int GetHashCode(int obj)
        {
            return obj;
        }
    }
    
    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        ////TestLibrary.TestFramework.BeginScenario("PosTest1: IEqualityOperator is implemented");

        try
        {
            int[] iArray = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                iArray[i] = i;
            }
            List<int> listObject = new List<int>(iArray);
            int ob = this.GetInt32(0, 1000);
            int result = listObject.LastIndexOf(ob, 999, 1000, new CustomIntIEqualityComparer());
            if (result != ob)
            {
                ////TestLibrary.TestFramework.LogError("001", "The result is not the value as expected,result is: " + result);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            //TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest2()
    {
        bool retVal = true;

        //TestLibrary.TestFramework.BeginScenario("PosTest2: Default Comparer is used");

        try
        {
            string[] strArray = { "apple", "dog", "banana", "chocolate", "dog", "food" };
            List<string> listObject = new List<string>(strArray);
            int result = listObject.LastIndexOf("dog", 3, 3, null);
            if (result != 1)
            {
                //TestLibrary.TestFramework.LogError("003", "The result is not the value as expected,result is: " + result);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            //TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest3()
    {
        bool retVal = true;

        //TestLibrary.TestFramework.BeginScenario("PosTest3: The generic type is a custom type. Default comparer is used");

        try
        {
            MyClass myclass1 = new MyClass();
            MyClass myclass2 = new MyClass();
            MyClass myclass3 = new MyClass();
            MyClass[] mc = new MyClass[3] { myclass1, myclass2, myclass3 };
            List<MyClass> listObject = new List<MyClass>(mc);
            int result = listObject.LastIndexOf(myclass3, 2, 1, null);
            int result2 = listObject.LastIndexOf(myclass3, 2, 1);
            if (result != 2)
            {
                //TestLibrary.TestFramework.LogError("005", "The result is not the value as expected,result is: " + result);
                retVal = false;
            }
            if (result != result2)
            {
                //TestLibrary.TestFramework.LogError("006", "The result is not the value as expected,result is: " + result);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            //TestLibrary.TestFramework.LogError("007", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    #endregion

    #region Nagetive Test Cases
    public bool NegTest1()
    {
        bool retVal = true;

        //TestLibrary.TestFramework.BeginScenario("NegTest1: The index is negative");

        try
        {
            int[] iArray = { 1, 9, -11, 3, 6, -1, 8, 7, 1, 2, 4 };
            List<int> listObject = new List<int>(iArray);
            int result = listObject.LastIndexOf(-11, -4, 3, null);
            //TestLibrary.TestFramework.LogError("101", "The ArgumentOutOfRangeException was not thrown as expected");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            //TestLibrary.TestFramework.LogError("102", "Unexpected exception: " + e);
            //TestLibrary.TestFramework.LogInformation(e.StackTrace);
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest2()
    {
        bool retVal = true;

        //TestLibrary.TestFramework.BeginScenario("NegTest2: index and count do not specify a valid section in the List");

        try
        {
            int[] iArray = { 1, 9, -11, 3, 6, -1, 8, 7, 1, 2, 4 };
            List<int> listObject = new List<int>(iArray);
            int result = listObject.LastIndexOf(-11, 6, 10, null);
            //TestLibrary.TestFramework.LogError("103", "The ArgumentOutOfRangeException was not thrown as expected");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            //TestLibrary.TestFramework.LogError("104", "Unexpected exception: " + e);
            //TestLibrary.TestFramework.LogInformation(e.StackTrace);
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest3()
    {
        bool retVal = true;

        //TestLibrary.TestFramework.BeginScenario("NegTest3: The count is a negative number");

        try
        {
            int[] iArray = { 1, 9, -11, 3, 6, -1, 8, 7, 1, 2, 4 };
            List<int> listObject = new List<int>(iArray);
            int result = listObject.LastIndexOf(-11, 1, -1, null);
            //TestLibrary.TestFramework.LogError("105", "The ArgumentOutOfRangeException was not thrown as expected");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            //TestLibrary.TestFramework.LogError("106", "Unexpected exception: " + e);
            //TestLibrary.TestFramework.LogInformation(e.StackTrace);
            retVal = false;
        }

        return retVal;
    }
    #endregion
    #endregion

    public static int Main()
    {
        ListLastIndexOf4 test = new ListLastIndexOf4();

        //TestLibrary.TestFramework.BeginTestCase("ListLastIndexOf3");

        if (test.RunTests())
        {
            //TestLibrary.TestFramework.EndTestCase();
            //TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            //TestLibrary.TestFramework.EndTestCase();
            //TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    private Int32 GetInt32(Int32 minValue, Int32 maxValue)
    {
        try
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue < maxValue)
            {
                return minValue + new Random().Next(maxValue - minValue); //TestLibrary.Generator.GetInt32(-55) % (maxValue - minValue);
            }
        }
        catch
        {
            throw;
        }

        return minValue;
    }
}
public class MyClass
{
}
