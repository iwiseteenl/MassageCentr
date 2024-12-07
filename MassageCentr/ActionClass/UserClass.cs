using MassageCentr.ActionClass.Account;
using MassageCentr.ActionClass.HelperClass;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MassageCentr.Interface;
using MassageCentr.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MassageCentr.ActionClass
{

    public class UserClass : IUser
    {
        private readonly DiagrammContext _context;
        private string? name;

        public UserClass(DiagrammContext context)
        {
            _context = context;
        }

        public List<string> AddAccount(AccountCreate account)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(account.Phone))
                    return new List<string> { "Поле с номером телефона не заполнено" };

                if (account.Phone.Length < 11)
                    return new List<string> { "Номер телефона не может быть меньше или больше 11 символов" };
                PersonDTO createUser = new PersonDTO()
                {

                    Name = account.Name,
                    Phone = account.Phone,
                    Email = account.Email
                };

                _context.Add(createUser);
                _context.SaveChanges();

                long ClientId = createUser.Id;

                Results.Created();
                return [$"Пользователь успешно создан Id - {ClientId}"];
            }
            catch (Exception)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }
        public List<PersonDTO> GetPersons()
        {
            try
            {
                var data = _context.Clients.Where(u => u.Name==name).Select(x => new PersonDTO
                {
                    Name = x.Name,
                    Email = x.EMail,
                    Id = x.ClientId,
                    Phone = x.PhoneNumber,
                }
                 ).ToList();
                return (List<PersonDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<PersonDTO> UpdatePersons(string name, PersonDTO person)
        {
            throw new NotImplementedException();
        }

        public List<PersonDTO> GetPerson(string name)
        {
            try
            {
                var data = _context.Clients.Where(u => u.Name == name).Select(x => new PersonDTO
                {
                    Name = x.Name,
                    Email = x.EMail,
                    Id = x.ClientId,
                    Phone = x.PhoneNumber,
                }
                ).ToList();
                return (List<PersonDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<PersonDTO> GetPersonDTO()
        {
            throw new NotImplementedException();
        }

        public List<string> DeletePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}