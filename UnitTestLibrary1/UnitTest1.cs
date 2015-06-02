using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation.Metadata;
using FotografApp.Model;
using FotografApp.Handler;
using FotografApp.Persistency;
using FotografApp.View;
using FotografApp.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        private static Register register;
        private static UserHandler userHandler;
        private static string _name = "";
        private static string _password = "";
        private static string _cpassword = "";
        private static string _email = "";
        private static string _tlf = "";
        public static int Id { get { return DatabasePersistencyHandler.Instance.GetUser(_email,_password).Id; }}

        [TestInitialize]
        public void BeforeTest()
        {
            register = new Register();
            userHandler = new UserHandler(new MainViewModel());
        }

        public bool CheckIfWorks()
        {
            return Register.ValidateUserRegistration(_name, _password, _cpassword, _email, _tlf);
        }
        
        [TestMethod]
        public void TestMethodManipulateUser()
        {
            //tester om bruger bliver tilføjet, logget ind, og slettet, hvor alle variabler er korrekte
            _name = "BondeHansen";
            _password = "123456";
            _cpassword = "123456";
            _email = "HansensKøer@får.gede";
            _tlf = "12345678";
            Assert.IsTrue(CheckIfWorks());
            Assert.IsTrue(Login.LoginAsUser(_email, _password));
            Assert.IsTrue(userHandler.DeleteUser(Id));
        }

        [TestMethod]
        public void TestMethodUser()
        {
            //tester om der retuneres falsk hvor navnet er for lille
            _name = "Bo";
            _password = "123456";
            _cpassword = "123456";
            _email = "HansensKøer@får.gede";
            _tlf = "12345678";
            Assert.IsFalse(CheckIfWorks());
        }

        [TestMethod]
        public void TestMethodUser1()
        {
            //tester om der retuneres falsk hvor koden er for lille
            _name = "BondeHansen";
            _password = "123";
            _cpassword = "123";
            _email = "HansensKøer@får.gede";
            _tlf = "12345678";
            Assert.IsFalse(CheckIfWorks());
        }

        [TestMethod]
        public void TestMethodUser2()
        {
            //tester om der retuneres falsk hvor password og confirm password retunere falsk
            _name = "BondeHansen";
            _password = "123456";
            _cpassword = "12345";
            _email = "HansensKøer@får.gede";
            _tlf = "12345678";
            Assert.IsFalse(CheckIfWorks());
        }

        [TestMethod]
        public void TestMethodUser3()
        {
            //tester om der retuneres falsk hvor emailen indeholder over 50 tegn
            _name = "BondeHansen";
            _password = "123456";
            _cpassword = "123456";
            _email = "HansensKøer@får.gede123456789123456789123456789123456789123456789123456789123456789";
            _tlf = "12345678";
            Assert.IsFalse(CheckIfWorks());
        }

        [TestMethod]
        public void TestMethodUser4()
        {
            //tester om der retuneres falsk hvor telefon nummeret ikke er lig 8
            _name = "BondeHansen";
            _password = "123456";
            _cpassword = "123456";
            _email = "HansensKøer@får.gede";
            _tlf = "1234567";
            Assert.IsFalse(CheckIfWorks());
        }

        [TestMethod]
        public void TestMethodUser5()
        {
            //tester om der retuneres falsk hvor navnet er for langt
            _name = "BondeHansen12345678912345678901472583690147258369014725836901472583699638527410";
            _password = "123456";
            _cpassword = "123456";
            _email = "HansensKøer@får.gede";
            _tlf = "12345678";
            Assert.IsFalse(CheckIfWorks());
        }
    }
}