using MassageCentr.ActionClass.Account;
using MassageCentr.ActionClass.HelperClass;

namespace MassageCentr.Interface
{
    public interface IUser
    {
        public List<string> AddAccount(AccountCreate account);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> DeletePerson(int id);
        public List<PersonDTO> GetPerson(string name);
        public List<PersonDTO> GetPersonDTO();

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<PersonDTO> UpdatePersons(string name, PersonDTO person);

        internal List<PersonDTO> GetPerson()
        {
            throw new NotImplementedException();
        }
    }
}
