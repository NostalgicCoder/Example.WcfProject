using System;
using System.ServiceModel.Activation;

namespace Example.WcfProject
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Customer : ICustomer
    {
        public CustomerResponse AddCustomer(CustomerRequest request)
        {
            CustomerResponse response = new CustomerResponse();

            try
            {
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.ToString();
            }

            return response;
        }

        public ReturnYourNameResponse ReturnYourName(CustomerRequest request)
        {
            ReturnYourNameResponse response = new ReturnYourNameResponse();

            try
            {
                if (!string.IsNullOrEmpty(request.CustomerDetails.Forename) && !string.IsNullOrEmpty(request.CustomerDetails.Surname))
                {
                    response.YourName = string.Format("{0} {1}", request.CustomerDetails.Forename, request.CustomerDetails.Surname);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMsg = "Missing forename and surname";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.ToString();
            }

            return response;
        }
    }
}
