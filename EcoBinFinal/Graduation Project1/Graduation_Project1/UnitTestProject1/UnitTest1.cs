using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graduation_Project1;  // LoginForm'un bulunduğu namespace
using System;


namespace UnitTestProject1
{
    [TestClass]
    public class LoginFormTests
    {
        private LoginForm _loginForm;

        // Testten önce LoginForm'u başlat
        [TestInitialize]
        public void SetUp()
        {
            _loginForm = new LoginForm();
        }

        // Geçerli kullanıcı adı ve şifre ile giriş testi
        [TestMethod]
        public void TestValidLogin()
        {
            // Arrange: Kullanıcı adı ve şifreyi belirleyin
            _loginForm.txtUserName.Text = "validUser";
            _loginForm.txtPassword.Text = "validPassword";

            // Act: Giriş butonuna tıklanır
            _loginForm.sButtonLog.PerformClick();

            // Assert: Hata mesajı olmamalı ve başarılı giriş yapılmalı
            Assert.AreEqual(true, _loginForm.statu); // Bu statü değerinin doğru olup olmadığını kontrol ederiz
            Assert.IsNull(_loginForm.ErrorMessage);  // Hata mesajı olmamalı
        }

        // Geçersiz kullanıcı adı ve şifre ile giriş testi
        [TestMethod]
        public void TestInvalidLogin()
        {
            // Arrange: Geçersiz kullanıcı adı ve şifreyi belirleyin
            _loginForm.txtUserName.Text = "invalidUser";
            _loginForm.txtPassword.Text = "invalidPassword";

            // Act: Giriş butonuna tıklanır
            _loginForm.sButtonLog.PerformClick();

            // Assert: Hata mesajı doğru olmalı
            Assert.AreEqual("Invalid Username or Password.", _loginForm.ErrorMessage);
        }

        // Boş kullanıcı adı ve şifre ile giriş testi
        [TestMethod]
        public void TestEmptyFields()
        {
            // Arrange: Kullanıcı adı ve şifreyi boş bırakıyoruz
            _loginForm.txtUserName.Text = "";
            _loginForm.txtPassword.Text = "";

            // Act: Giriş butonuna tıklanır
            _loginForm.sButtonLog.PerformClick();

            // Assert: Hata mesajı doğru olmalı
            Assert.AreEqual("Invalid Username or Password.", _loginForm.ErrorMessage);  // Bu mesajı kontrol ediyoruz
        }
    }
}
