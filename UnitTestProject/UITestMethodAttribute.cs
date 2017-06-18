using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace UnitTestProject
{
    public class UITestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (testMethod.GetAttributes<AsyncStateMachineAttribute>(false).Length != 0)
            {
                throw new NotSupportedException("async TestMethod with UITestMethodAttribute are not supported. Either remove async or use TestMethodAttribute.");
            }

            TestResult result = null;

            CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                result = testMethod.Invoke(new object[0]);
            }).AsTask().GetAwaiter().GetResult();

            return new TestResult[] { result };
        }
    }
}