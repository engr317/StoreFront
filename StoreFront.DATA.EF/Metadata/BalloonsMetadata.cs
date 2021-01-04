using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA.EF
{
    #region Balloon MetaData
    public class BalloonMetaData
    {
        [Display(Name ="Balloon Title")]
        [Required(ErrorMessage = "* Title is required")]
        [StringLength(50, ErrorMessage = "* Balloon title must be 50 characters or less.")]
        public string BalloonTitle { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [Required(ErrorMessage = "* Description is required")]
        public string Description { get; set; }

        [Key]
        public int GenreID { get; set; }

        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[N/A]")]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "* Price is required")]
        public Nullable<decimal> Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "*Value must be a valid number, 0 or larger")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[N/A]")]
        [Display(Name = "Units Sold")]
        public Nullable<int> UnitsSold { get; set; }

        [Display(Name = "Published")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[N/A]")]
        public Nullable<System.DateTime> ProdDate { get; set; }

        [Key]
        [Display(Name = "Distributor")]
        public int DistributorsID { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public string BalloonImg { get; set; }

        [Display(Name = "Category Feature")]
        [Required(ErrorMessage = "* Category is required")]
        public bool IsCategoryFeature { get; set; }

        [Display(Name = "Status")]
        public int BalloonStatusID { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "* Type is required")]
        [DisplayFormat(NullDisplayText = "City is null")]
        public Nullable<int> TypeID { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "* Size is required")]
        public string Size { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "* Color is required")]
        public string Color { get; set; }

        [Key]
        public int ManufactID { get; set; }

        [Key]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public Nullable<int> AccessID { get; set; }
    }
    [MetadataType(typeof(BalloonMetaData))]
    public partial class Balloon { }

    #endregion

    #region BalloonStatus MetaData
    public class BalloonStatusMetadata
    {
        [Required(ErrorMessage = "* Required")]
        [StringLength(15, ErrorMessage = "* Balloon Status must be 15 characters or less. ")]
        [Display(Name = "Status")]
        public string BalloonStatusName { get; set; }

        [DisplayFormat(NullDisplayText = "[N/A]")]
        [UIHint("MultilineText")]
        public string Notes { get; set; }
    }
    [MetadataType(typeof(BalloonStatusMetadata))]
    public partial class BalloonStatus { }
    #endregion

    #region Billing_Information MetaData
    public class Billing_InformationMetaData
    {



        public string Email { get; set; }

        [Required(ErrorMessage = "* First Name is Required")]
        [StringLength(15, ErrorMessage = "* First Name must be 15 characters or less. ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Last Name is Required")]
        [StringLength(15, ErrorMessage = "* Last Name must be 15 characters or less. ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "* Address is Required")]
        [Display(Name = "Address Line 1")]
        public string Address_1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address_2 { get; set; }

        [StringLength(50, ErrorMessage = "* City must be 50 characters or less")]
        [DisplayFormat(NullDisplayText = "City is null")]
        public string City { get; set; }

        [Display(Name ="State")]
        public int StateID { get; set; }

        [StringLength(5, ErrorMessage = "* ZipCode must be 5 characters or less")]
        [DisplayFormat(NullDisplayText = "Zip is null")]
        [Display(Name = "ZipCode")]
        public string Zip { get; set; }


        public string Phone { get; set; }
    }
    [MetadataType(typeof(Billing_InformationMetaData))]
    public partial class Billing_Information { }
    #endregion

    #region Department MetaData
    public class DepartmentMetaData
    {
        [StringLength(20, ErrorMessage = "* The value must be 20 char or less")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string Department1 { get; set; }
    }
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department { }
    #endregion

    #region Distributer MetaData
    public class DistributorMetaData
    {
        public string DIstributorName { get; set; }

        [StringLength(50, ErrorMessage = "* City must be 50 characters or less")]
        [DisplayFormat(NullDisplayText = "City is null")]
        public string CIty { get; set; }

        [StringLength(2, ErrorMessage = "* State must be 2 characters or less")]
        [DisplayFormat(NullDisplayText = "State is null")]
        public int StateID { get; set; }


        public bool IsActive { get; set; }

    }
    [MetadataType(typeof(DistributorMetaData))]
    public partial class Distributor { }
    #endregion

    #region Employee MetaData
    public class EmployeeMetaData
    {
        [Required(ErrorMessage = "* Required")]
        [StringLength(20, ErrorMessage = "* First Name must be 15 characters or less. ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(20, ErrorMessage = "* Last Name must be 15 characters or less. ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* Title is Required")]
        [StringLength(20, ErrorMessage = "* Title must be 20 characters or less. ")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Date Hired")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[N/A]")]
        public System.DateTime HireDate { get; set; }

        [Key]
        public int ReportID { get; set; }

        [Key]
        public int DeptID { get; set; }
    }
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee { }
    #endregion

    #region Manufacturer MetaData
    public class ManufacturerMetaData
    {
        [Required(ErrorMessage = "*Company Name is Required")]
        [StringLength(50, ErrorMessage = "* Company Name must be 50 characters or less. ")]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [StringLength(50, ErrorMessage = "* City must be 50 characters or less")]
        [DisplayFormat(NullDisplayText = "City is null")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "* State must be 2 characters or less")]
        [DisplayFormat(NullDisplayText = "State is null")]
        public int StateID { get; set; }

        [StringLength(10, ErrorMessage = "* ZipCode must be 10 characters or less")]
        [DisplayFormat(NullDisplayText = "Zip is null")]
        public string ZipCode { get; set; }

        [StringLength(30, ErrorMessage = "* Country must be 30 characters or less")]
        [DisplayFormat(NullDisplayText = "Country is null")]
        public string Country { get; set; }
    }
    #endregion

    #region Payment MetaData
    public class PaymentMetaData
    {       

        [Display(Name = "Cash")]
        public bool isCash { get; set; }

        [Display(Name = "Check")]
        public bool isCheck { get; set; }

        [Display(Name = "Charge")]
        public bool isCard { get; set; }

        [Display(Name = "Check No.")]
        [StringLength(20, ErrorMessage = "* The value must be 14 char or less")]
        public string CheckNbr { get; set; }

        [Display(Name = "Card No.")]
        [StringLength(20, ErrorMessage = "* The value must be 14 char or less")]
        public string CardNbr { get; set; }
    }
    [MetadataType(typeof(PaymentMetaData))]
    public partial class Payment { }
    #endregion

    #region Seasonal MetaData
    public class SeasonalMetaData
    {
        [Required(ErrorMessage = "* Season is Required")]
        [StringLength(20, ErrorMessage = "* First Name must be 20 characters or less. ")]
        [Display(Name = "Season")]
        public string SeasonName { get; set; }
    }
    [MetadataType(typeof(SeasonalMetaData))]
    public partial class Seasonal { }
    #endregion

    #region Shipper MetaData
    public class ShipperMetaData
    {
        public string ShipVIA { get; set; }
        public string FIrstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int StateID { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public bool Residential { get; set; }
        public bool Commercial { get; set; }
        public string Notes { get; set; }
        public Nullable<int> BalloonID { get; set; }
    }
    [MetadataType(typeof(ShipperMetaData))]
    public partial class Shipper { }
    #endregion

}