﻿namespace CanfieldSchool.Login_Register
{
    public class User
    {
         public int Id { get; set; }

        public string ? UserName { get; set; }

        public string ? LastName { get; set; }

        public string ? Email { get; set; }

        public byte[] ? PasswordHash { get; set; }

        public byte[] ? PasswordSalt  { get; set; }

    }
}
