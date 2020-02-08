////------------------------------------------------------------------------
////<copyright file="AnnotationUser.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.Annotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// Annotation test for User
    /// </summary>
    public class AnnotationUser
    {
        /// <summary>
        /// Annotations the test.
        /// </summary>
        public static void AnnotationTest()
        {
            AnnotationsMain customer = new AnnotationsMain();
            customer.CustomerNameIs = "Bhush";
            customer.ShopNameIs = "SriRamGeneral";
            customer.MobileNumberIs = 9632102369;
            customer.IDIs = 12155;
            var context = new ValidationContext(customer);
            var result = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(customer, context, result, true);
            foreach (ValidationResult validationResult in result)
            {
                Console.WriteLine(validationResult);
            }

            if (isValid)
            {
                Console.WriteLine("Name\t\t: " + customer.CustomerNameIs);
                Console.WriteLine("Shop Name\t: " + customer.ShopNameIs);
                Console.WriteLine("Mobile Number\t: " + customer.MobileNumberIs);
                Console.WriteLine("ID\t\t: " + customer.IDIs);
            }
        }
    }
}
