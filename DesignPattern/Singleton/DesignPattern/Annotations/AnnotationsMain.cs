////------------------------------------------------------------------------
////<copyright file="AnnotationsMain.cs" company="BridgeLabz">
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
    /// Annotations Main program
    /// </summary>
    public class AnnotationsMain
    {
        /// <summary>
        /// The customer name
        /// </summary>
        private string customerName;

        /// <summary>
        /// The shop name
        /// </summary>
        private string shopName;

        /// <summary>
        /// The mobile number
        /// </summary>
        private long mobileNumber;

        /// <summary>
        /// The i d
        /// </summary>
        private int iD;

        /// <summary>
        /// Gets or sets the customer name is.
        /// </summary>
        /// <value>
        /// The customer name is.
        /// </value>
        [Required(ErrorMessage = "Customer Name is Required")]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,20}", ErrorMessage = "Name : Charectors not allowed/First Charactor Should be Capital")]
        public string CustomerNameIs
        {
            get
            {
                return this.customerName;
            }

            set
            {
                this.customerName = value;
            }
        }

        /// <summary>
        /// Gets or sets the shop name is.
        /// </summary>
        /// <value>
        /// The shop name is.
        /// </value>
        [Required(ErrorMessage = "Customer Shop Name is Required")]
        [RegularExpression(@"^[A-Z]{1}[a-zA-Z]{2,20}")]
        public string ShopNameIs
        {
            get
            {
                return this.shopName;
            }

            set
            {
                this.shopName = value;
            }
        }

        /// <summary>
        /// Gets or sets the mobile number is.
        /// </summary>
        /// <value>
        /// The mobile number is.
        /// </value>
        [Required(ErrorMessage = "Customer Mobile Number is Required")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$", ErrorMessage = ("It needs 10 digit number/first digit should be ( 6 - 9 )"))]
        public long MobileNumberIs
        {
            get
            {
                return this.mobileNumber;
            }

            set
            {
                this.mobileNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the i d is.
        /// </summary>
        /// <value>
        /// The i d is.
        /// </value>
        [Required(ErrorMessage = "Customer ID is Required")]
        [RegularExpression(@"[1-9]{1}[0-9]{4}", ErrorMessage = "Your id should be 5 digits/first digit should be non zero")]
        public int IDIs
        {
            get
            {
                return this.iD;
            }

            set
            {
                this.iD = value;
            }
        }
    }
}
