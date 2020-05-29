using System;
using Tone.Domain.ValueObjects;
using Tone.Shared.Entities;
using Tone.Domain.Enums;

namespace Tone.Domain.Entities
{
    public class User : Entity
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public EUserStatus Status { get; private set; }
        public DateTime Birthday { get; private set; }
        public Address Address { get; private set; }
        public string Image { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public User(Name name, Email email, string password, DateTime birthday, Address address, string image)
        {
            Name = name;
            Email = email;
            Password = password;
            Status = EUserStatus.Active;
            Birthday = birthday;
            Address = address;
            Image = image;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public User(Name name, Email email, string password, EUserStatus status, DateTime birthday, Address address, string image)
        {
            Name = name;
            Email = email;
            Password = password;
            Status = status;
            Birthday = birthday;
            Address = address;
            Image= image;
            UpdatedAt = DateTime.Now;
        }

        public bool UploadImage(string file)
        {
            // TODO: Upload image to Azure.
            return false;
        }

        public void ChangeStatus(EUserStatus status)
        {
            if (this.Status != status)
                this.Status = status;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
