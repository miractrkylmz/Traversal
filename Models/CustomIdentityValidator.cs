﻿using Microsoft.AspNetCore.Identity;

namespace Traversal.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre minimum {length} karakter olmalıdır"
            };

        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifre en az bir büyük harf içermelidir"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "Şifre en az bir küçük harf içermelidir"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code= "PasswordRequiresNonAlphanumeric",
                Description = "Şifre en az bir alfanumerik karakter içermelidir"
                
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = "Şifre en az bir rakam içermelidir ('0'-'9')"
            };
        }
    }
}
