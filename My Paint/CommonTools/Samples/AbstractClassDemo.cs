using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class iPhone
{
    public void Call()
    {
        Console.WriteLine("Call Method: This method provides Calling features");
    }
    public void Message()
    { }
    public abstract void Model();
    public abstract void Color();
}

interface Ifingerprint
{
    void FingerPrintReader();
}

class iPhone5s : iPhone
{
    public override void Model()
    {
        Console.WriteLine("Model: The model of this iPhone is iPhone5s");
    }

    public void LaunchDate()
    {
        Console.WriteLine("Launch Date: This iPhone was launched on 20-September-2013");
    }

    public override void Color()
    {

    }
}

class iPhone6 : iPhone, Ifingerprint
{
    public override void Model()
    {
        Console.WriteLine("Model: The model of this iPhone is iPhone5s");
    }

    public void LaunchDate()
    {
        Console.WriteLine("Launch Date: This iPhone was launched on 20-September-2013");
    }

    public override void Color()
    {

    }

    #region Ifingerprint Members

    public void FingerPrintReader()
    {
    }

    #endregion
}
class Program
{
    static void AbstractClassDemo(string[] args)
    {
        iPhone5s iphone5s = new iPhone5s();
        iphone5s.Call();
        iphone5s.Model();
        iphone5s.LaunchDate();
        Console.ReadKey();
    }
}
