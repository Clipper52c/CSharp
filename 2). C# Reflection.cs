using System;
using System.Linq;
using System.Reflection;

class TestAttribute : Attribute { }
class TestMethodAttribute: Attribute { }

[TestAttribute]
class MyTestSuite
{
    
    public void HelperMethod()
    {
        Console.WriteLine("this method will never be invoke because it does not have a TestAttribute on it.");
    }

    [TestMethod]
    public void Test1()
    {
        Console.WriteLine("Doing some testing ...");
    }

    [TestMethod]
    public void Test2()
    {
        Console.WriteLine("Doing some other testing ...");
    }
}


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var testSuites = 
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
                select t;

            foreach(Type t in testSuites)
            {
                Console.WriteLine("Running tests in suite: " + t.Name);
                var testMethods = 
                    from m in t.GetMethods()
                    where m.GetCustomAttributes(false).Any(a => a is TestMethodAttribute)
                    select m;

                object testSuiteInstance = Activator.CreateInstance(t);
                
                foreach(MethodInfo mInfo in testMethods)
                {
                    mInfo.Invoke(testSuiteInstance, null);
                }

            }
        }
    }
}
