using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA.EF.Metadata
{
    #region Balloon MetaData
    public class BalloonMetaData
    {
        public string SerialNo { get; set; }
        public string BalloonTitle { get; set; }
        public string Description { get; set; }
        public int GenreID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> UnitsSold { get; set; }
        public Nullable<System.DateTime> ProdDate { get; set; }
        public int DistributorsID { get; set; }
        public string BalloonImg { get; set; }
        public bool IsCategoryFeature { get; set; }
        public int BalloonStatusID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int ManufactID { get; set; }
        public Nullable<int> AccessID { get; set; }
    }
    [MetadataType(typeof(BalloonMetaData))]
    public partial class Balloon { }

    #endregion

    #region BalloonStatus MetaData
    public class BalloonStatusMetadata
    {
        public string BalloonStatusName { get; set; }
        public string Notes { get; set; }
    }
    [MetadataType(typeof(BalloonStatusMetadata))]
    public partial class BalloonStatus { }
    #endregion

    #region Billing_Information MetaData
    public class Billing_InformationMetaData
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
    }
    [MetadataType(typeof(Billing_InformationMetaData))]
    public partial class Billing_Information { }
    #endregion

    #region Department MetaData
    public class DepartmentMetaData
    {
        public string Department1 { get; set; }
    }
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department { }
    #endregion

    #region Distributer MetaData
    public class DistributorMetaData
    {
        public string DIstributorName { get; set; }
        public string CIty { get; set; }
        public int StateID { get; set; }
        public bool IsActive { get; set; }

    }
    [MetadataType(typeof(DistributorMetaData))]
    public partial class Distributor { }
    #endregion

    #region Employee MetaData
    public class EmployeeMetaData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public System.DateTime HireDate { get; set; }
        public int ReportID { get; set; }
        public int DeptID { get; set; }
    }
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee { }
    #endregion

    #region Manufacturer MetaData
    public class ManufacturerMetaData
    {
        public string CompanyName { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
    #endregion

    #region Payment MetaData
    public class PaymentMetaData
    {
        public bool isCash { get; set; }
        public bool isCheck { get; set; }
        public bool isCard { get; set; }
        public string CheckNbr { get; set; }
        public string CardNbr { get; set; }
    }
    [MetadataType(typeof(PaymentMetaData))]
    public partial class Payment { }
    #endregion

    #region Seasonal MetaData
    public class SeasonalMetaData
    {
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