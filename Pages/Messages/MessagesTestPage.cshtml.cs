using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Pages.Messages
{
    public class MessagesTestPageModel : PageModel
    {
        private IMessageService _messageService;
        private UserManager<AppUser> _userManager;

        public MessagesTestPageModel(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public IEnumerable<Message> MyReceivedMessages { get; set; }

        public IEnumerable<Message> MySentMessages { get; set; }
        [BindProperty]
        public Message NewMessage { get; set; }

        public AppUser CurrentUser { get; set; }

        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            MySentMessages = _messageService.GetSentMessage(CurrentUser.Id);
            MyReceivedMessages = _messageService.GetReceivedMessages(CurrentUser.Id);


        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                NewMessage.SendingDate=DateTime.Now;
                _messageService.CreateMessage(NewMessage);
                return RedirectToPage("MessagesTestPage");
            }
            else
            {
                CurrentUser = await _userManager.GetUserAsync(User);
                MySentMessages = _messageService.GetSentMessage(CurrentUser.Id);
                MyReceivedMessages = _messageService.GetReceivedMessages(CurrentUser.Id);
                return Page();
            }

            

        }
    }
}
