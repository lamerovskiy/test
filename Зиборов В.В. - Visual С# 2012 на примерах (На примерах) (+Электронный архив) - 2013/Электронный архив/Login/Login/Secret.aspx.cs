// Третья форма Secret.aspx. К этой странице имеют доступ только
// зарегистрированные пользователи. Вначале пытаемся (Try) определить,
// с какой веб-страницы пришел пользователь на данный ресурс. Если не
// удается (ветка Catch, т. е. пользователь пытается открыть данный
// закрытый ресурс, набрав его URL-адрес в адресной строке браузера), то
// сообщаем пользователю, что он не зарегистрирован, и делаем видимой
// кнопку "Регистрация". Если удается определить URL-адрес страницы, с
// которой пользователь пришел на данную страницу, то разрешаем доступ к
// закрытой информации только для адресов /Login.aspx и /Registration.aspx.
using System;
using System.Web.UI.WebControls;
// Другие директивы using удалены, поскольку они не используются в данной
// программе
namespace Login
{
    public partial class Secret : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Обработка события "загрузка страницы"
            Button1.Visible = false; Button1.Text = "Регистрация";
            String URL_адрес;
            // Определение, с какой веб-страницы вы пришли на данную
            // страницу, т. е. определение локального адреса (пути)
            try
            {
                URL_адрес = Request.UrlReferrer.LocalPath;
                // Более эффективно определять абсолюный виртуальный адрес:
                // URL_адрес = Request.UrlReferrer.AbsoluteUri
                if (URL_адрес == @"/Login.aspx" ||
                       URL_адрес == @"/Registration.aspx")
                {
                    Label1.Text = "Поскольку Вы являетесь " +
                        "зарегистрированным пользователем, то Вы имеете " +
                        "доступ к закрытой информации. Вы пришли на эту" +
                        " страницу со страницы " + URL_адрес;
                    return;
                }
            }
            catch (Exception Ситуация)
            {
                Label1.Text = "Вы не являетесь зарегистрированным " +
                   "пользователем, поскольку пришли на эту страницу " +
                   "набрав URL-адрес в адресной строке браузера.<br />" +
                   Ситуация.Message;
                Button1.Visible = true;
                return;
            }
            Label1.Text = "Вы не являетесь зарегистрированным " +
               "пользователем, поскольку пришли со страницы " +
               URL_адрес;
            Button1.Visible = true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Щелчок на кнопке "Регистрация"
            Response.Redirect("Registration.aspx");
        }
    }
}
