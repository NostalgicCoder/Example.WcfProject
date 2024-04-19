using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Example.WcfProject
{
    [DataContract]
    public class ValidationResponse
    {
        [DataMember(IsRequired = true)]
        public bool Success;

        [DataMember]
        public string ErrorMsg;
    }

    [DataContract]
    public class AddressDetails
    {
        [DataMember(IsRequired = true)]
        public string NameNumber;

        [DataMember(IsRequired = true)]
        public string StreetLine1;

        [DataMember]
        public string StreetLine2;

        [DataMember(IsRequired = true)]
        public string Town;

        [DataMember]
        public string County;

        [DataMember(IsRequired = true)]
        public string PostCode;

        [DataMember]
        public string Country;
    }

    [DataContract]
    public class CustomerDetails
    {
        [DataMember(IsRequired = true)]
        public string Forename;

        [DataMember(IsRequired = true)]
        public string Surname;

        [DataMember(IsRequired = true)]
        public DateTime DOB;
    }

    [DataContract]
    public class CustomerRequest
    {
        [DataMember(IsRequired = true)]
        public CustomerDetails CustomerDetails;

        [DataMember(IsRequired = true)]
        public AddressDetails AddressDetails;
    }

    [DataContract]
    public class CustomerResponse : ValidationResponse
    {
    }

    [DataContract]
    public class ReturnYourNameResponse : ValidationResponse
    {
        [DataMember(IsRequired = true)]
        public string YourName;
    }

    [ServiceContract]
    public interface ICustomer
    {
        [OperationContract]
        CustomerResponse AddCustomer(CustomerRequest request);

        [OperationContract]
        ReturnYourNameResponse ReturnYourName(CustomerRequest request);
    }
}
