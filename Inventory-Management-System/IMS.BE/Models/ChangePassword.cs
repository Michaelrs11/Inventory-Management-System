﻿using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace IMS.BE.Models
{
    public class ChangePassword
    {

        public string? UserCode { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Old Password")]
        public string OldPassword { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "New Password")]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Password and Confirmation Password tidak sama")]
        [Display(Name = "Password", Prompt = "Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}