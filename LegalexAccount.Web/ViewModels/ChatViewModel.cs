namespace LegalexAccount.Web.ViewModels
{
    public class ChatViewModel
    {
        public string ChatName { get; set; }
        public List<ChatViewModel> AnotherChats { get; set; }
        public string LastMessage { get; set; }
    }
}
