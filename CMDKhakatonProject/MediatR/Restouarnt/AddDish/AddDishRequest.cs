﻿using CMDKhakatonProject.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class AddDishRequest : IRequest<IActionResult>
    {
        #region Attribute
        [Required]
        #endregion
        public string Name { get; set; }
        #region Attribute
        [Required]
        #endregion
        public string Description { get; set; }
        #region Attribute
        [Required]
        [PositiveNumber(ErrorMessage = $"Value {nameof(Price)} can be positive.")]
        #endregion
        public double Price { get; set; }
        #region Attribute
        [Required]
        [PositiveNumber(ErrorMessage = $"Value {nameof(CookinTime)} can be positive.")]
        #endregion
        public double CookinTime { get; set; }
        #region Attribute 
        [Required]
        #endregion
        public double Calories { get; set; }
        #region Attribute
        [Required]
        #endregion
        public IFormFile PreviewPhoto { get; set; }
        #region Attribute
        [Required]
        [MinLength(1, ErrorMessage = "Please select at least one file.")]
        #endregion
        public IFormFile[] Photos { get; set; }
        #region Attribute
        [JsonIgnore]
        #endregion
        public ClaimsPrincipal? User;
    }
}
