using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Pages.Messages
{
    
    public class MessagesModel : PageModel
    {
        private IMessageService _messageService;
        private UserManager<AppUser> _userManager;

        public MessagesModel(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [BindProperty]
        public Message NewMessage { get; set; }
        [ValidateNever]
        public AppUser CurrentUser { get; set; }
        [BindProperty]
        public int ListLength { get; set; }
        
        public List<Message> Messages { get; set; }

        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            Messages = _messageService.GetMessagesByUserId(CurrentUser.Id);
            ListLength = 8;
        }

        public async Task<IActionResult> OnPostSendAsync()
        {
            NewMessage.SendingDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Messages");
            }
            _messageService.CreateMessage(NewMessage);
            return RedirectToPage("Messages");
        }

        public async Task<IActionResult> OnPostReplyAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            Messages = _messageService.GetMessagesByUserId(CurrentUser.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostLoadAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            Messages = _messageService.GetMessagesByUserId(CurrentUser.Id);
            ListLength += 5;
            return Page();
        }
    }
}
