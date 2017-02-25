using PrasannaNeons.DataEntities;

namespace PrasannaNeons.Models
{
    public class UserModel : CustomerUser
    {
        public string RememberMe { get; set; }
    }
}