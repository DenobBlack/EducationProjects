using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace TestUI
{
    public class UnitTest1
    {
        [Fact]
        public void TestUI()
        {
            using (UIA3Automation automation = new UIA3Automation())
            {
                var app = Application.Launch(@"C:\Temp\ИСПП-21\AuthApp\bin\Debug\net8.0-windows\AuthApp.exe");
                var window = app.GetMainWindow(automation);

                Button buttonReg = window.FindFirstDescendant(b => b.ByText("Зарегистрироваться")).AsButton();
                Assert.NotNull(buttonReg);
                buttonReg.Click();

                var messageBox = window.FindFirstDescendant(m => m.ByText("Заполните все поля"));
                Assert.NotNull(messageBox);
                var buttonOk = window.FindFirstDescendant(r => r.ByAutomationId("2")).AsTextBox();
                buttonOk.Click();

                var loginBox = window.FindFirstDescendant(r => r.ByAutomationId("1")).AsTextBox();
                loginBox.Enter("max123");
                var passwordBox = window.FindFirstDescendant(r => r.ByAutomationId("ter")).AsTextBox();
                passwordBox.Text = "Gh7$d_ghn8";
                var assertPasswordBox = window.FindFirstDescendant(r => r.ByAutomationId("3")).AsTextBox();
                assertPasswordBox.Enter("lksadfjsfjsafjdfl;ksdkjadlalkf");
                buttonReg.Click();
                messageBox = window.FindFirstDescendant(m => m.ByText("Пароли не совпадают"));
                Assert.NotNull(messageBox);
                buttonOk = window.FindFirstDescendant(r => r.ByAutomationId("2")).AsTextBox();
                buttonOk.Click();

                loginBox.Enter("max123");
                passwordBox.Text = "G$_g8";
                assertPasswordBox.Enter("G$_g8");
                buttonReg.Click();
                messageBox = window.FindFirstDescendant(m => m.ByText("Пароль небезопасен, он должен содержать большие и маленькие буквы, цифры и специальные символы"));
                Assert.NotNull(messageBox);
                buttonOk = window.FindFirstDescendant(r => r.ByAutomationId("2")).AsTextBox();
                buttonOk.Click();

                loginBox.Enter("max123");
                passwordBox.Text = "G$_g8G$_";
                assertPasswordBox.Enter("G$_g8G$_");
                buttonReg.Click();
                messageBox = window.FindFirstDescendant(m => m.ByText("Вы успешно зарегистрированы"));
                Assert.NotNull(messageBox);
                buttonOk = window.FindFirstDescendant(r => r.ByAutomationId("2")).AsTextBox();
                buttonOk.Click();


            }
        }
    }
}