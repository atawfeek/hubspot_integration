using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubspot_integration
{
    static class ContactFactory
    {
        static public ContactModel Create(string name, string phone)
        {
            return new ContactModel
            {
                properties = new List<Property>
                {
                    new Property
                    {
                        property = "email",
                        value = $"{phone}@gig.com.eg"
                    },
                    new Property
                    {
                        property = "firstname",
                        value = name
                    },
                    new Property
                    {
                        property = "mobilephone",
                        value = phone
                    }
                }
            };
        }
    }
}
