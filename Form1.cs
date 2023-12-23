using System;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_joinbot
{
    public partial class Form1 : Form
    {
        TelegramBotClient client = new TelegramBotClient("6729845188:AAGuXS1RFTtOOVBx4kIASjfpgUqViJgonBI");
        string lastMessage = "";
        [Obsolete]
        public Form1()
        {
            InitializeComponent();

            client.StartReceiving();
            client.OnMessage += Client_OnMessage;
        }

        [Obsolete]
        private void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var UserId = e.Message.Chat.Id;
            var Message = e.Message.Text;

            var Button = new InlineKeyboardButton[][]
            {
                new []
                {
                   InlineKeyboardButton.WithUrl("پیوستن", "https://t.me/MuCeFiD")
                }
            };

            var Markup = new InlineKeyboardMarkup(Button);

            if (!Message.Equals(lastMessage))
            {
                client.SendTextMessageAsync(UserId, "کانال ما", replyMarkup: Markup);
            }
        }
    }
}
