using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graduation_Project1;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private LoginForm _loginForm;

        // Her testten önce çalışacak metodu belirler
        [TestInitialize]
        public void SetUp()
        {
            _loginForm = new LoginForm();

        }

        [TestMethod]
        public void TestMethod1()
        {
            


        }
    }
}
