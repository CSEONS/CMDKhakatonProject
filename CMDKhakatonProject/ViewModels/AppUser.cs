﻿namespace CMDKhakatonProject.ViewModels
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role {  get; set; }
        public string? PhotoBase64 { get; set; }
    }
}
