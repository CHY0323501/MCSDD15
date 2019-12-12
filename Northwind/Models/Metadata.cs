using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Models
{
    //將所有由程式產生的資料表類別(partial class)複製過來，把partial刪除、並且只留欄位就好，其他可不留，並在原來的class加上[MetadataType(typeof(MetadataEmployees))]
    public class MetadataCategories
        {
            [DisplayName("產品類別編號")]
            public int CategoryID { get; set; }
            [DisplayName("產品類別名稱")]
            [Required(ErrorMessage = "請輸入產品類別名稱")]
            [StringLength(15, ErrorMessage = "最多輸入15字")]
            public string CategoryName { get; set; }
            [DisplayName("產品類別說明")]
            [Required(ErrorMessage = "請輸入類別說明")]
            public string Description { get; set; }
            [DisplayName("產品類別圖片")]
            [Required(ErrorMessage = "請選擇產品類別圖片")]
            public byte[] Picture { get; set; }
        }
        public  class MetadataCustomers
    {
            [DisplayName("客戶編號")]
            [Required(ErrorMessage = "請輸入客戶編號")]
            [RegularExpression("[A-Z]{5}", ErrorMessage = "請輸入A~Z英文五碼")]
            [CheckCustomerID]
            public string CustomerID { get; set; }
            [DisplayName("公司名稱")]
            [Required(ErrorMessage = "請輸入公司名稱")]
            [StringLength(40, ErrorMessage = "長度最長40字")]
            public string CompanyName { get; set; }
            [DisplayName("聯絡人")]
            [Required(ErrorMessage = "請輸入聯絡人")]
            [StringLength(30, ErrorMessage = "長度最長30字")]
            public string ContactName { get; set; }
            [DisplayName("聯絡人職稱")]
            [Required(ErrorMessage = "請輸入聯絡人職稱")]
            [StringLength(30, ErrorMessage = "長度最長30字")]
            public string ContactTitle { get; set; }
            [DisplayName("地址")]
            [Required(ErrorMessage = "請輸入地址")]
            [StringLength(60, ErrorMessage = "長度最長60字")]
            public string Address { get; set; }
            [DisplayName("郵遞區號")]
            [StringLength(10, ErrorMessage = "長度最長10字")]
            public string PostalCode { get; set; }
            [DisplayName("電話")]
            [Required(ErrorMessage = "請輸入電話")]
            [StringLength(24, ErrorMessage = "長度最長24字")]
            public string Phone { get; set; }
            [DisplayName("傳真電話")]
            [StringLength(24, ErrorMessage = "長度最長24字")]
            public string Fax { get; set; }

        }
        public  class MetadataEmployees
    { 
            [DisplayName("員工編號")]
            public int EmployeeID { get; set; }
            [DisplayName("姓氏")]
            [Required(ErrorMessage = "請輸入姓氏")]
            [StringLength(20, ErrorMessage = "姓氏最長20字")]
            public string LastName { get; set; }
            [DisplayName("名字")]
            [Required(ErrorMessage = "請輸入名字")]
            [StringLength(10, ErrorMessage = "名字最長10字")]
            public string FirstName { get; set; }
            [DisplayName("職稱")]
            [Required(ErrorMessage = "請輸入職稱")]
            [StringLength(30, ErrorMessage = "職稱最長30字")]
            public string Title { get; set; }
            [DisplayName("稱呼")]
            [Required(ErrorMessage = "請輸入稱呼")]
            [StringLength(25, ErrorMessage = "稱呼最長25字")]
            public string TitleOfCourtesy { get; set; }
            [DisplayName("出生日期")]
            [Required(ErrorMessage = "請輸入生日")]
            [DataType(DataType.DateTime,ErrorMessage ="輸入日期有誤")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public System.DateTime BirthDate { get; set; }
            [DisplayName("雇用日期")]
            [Required(ErrorMessage = "請輸入雇用日期")]
            [DataType(DataType.DateTime, ErrorMessage = "輸入日期有誤")]
            [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
            public System.DateTime HireDate { get; set; }
            [DisplayName("地址")]
            [Required(ErrorMessage = "請輸入地址")]
            [StringLength(60, ErrorMessage = "地址最長60字")]
            public string Address { get; set; }
            [DisplayName("郵遞區號")]
            [StringLength(10, ErrorMessage = "郵遞區號最長10字")]
            public string PostalCode { get; set; }
            [DisplayName("電話號碼")]
            [Required(ErrorMessage = "請輸入電話號碼")]
            [StringLength(24, ErrorMessage = "電話號碼最長24字")]
            public string HomePhone { get; set; }
            [DisplayName("分機號碼")]
            [StringLength(4, ErrorMessage = "分機號碼最長4字")]
            public string Extension { get; set; }
            [DisplayName("個人照片")]
            [Required(ErrorMessage = "請選擇個人照片")]
            public byte[] Photo { get; set; }
            [DisplayName("附註")]
            public string Notes { get; set; }
            [DisplayName("主管")]
            public Nullable<int> ReportsTo { get; set; }

        }
        public  class MetadataOrderDetails
    {
            [DisplayName("訂單號碼")]
            public int OrderID { get; set; }
            [DisplayName("產品編號")]
            public int ProductID { get; set; }
            [DisplayName("單價")]
            [Required(ErrorMessage = "請輸入單價")]
            [Range(double.Epsilon, double.MaxValue, ErrorMessage = "單價不可小於0")]
            public decimal UnitPrice { get; set; }
            [DisplayName("數量")]
            [Required(ErrorMessage = "請輸入數量")]
            [Range(1, int.MaxValue, ErrorMessage = "數量不可小於1")]
            public short Quantity { get; set; }
            [DisplayName("折扣")]
            [Required(ErrorMessage = "請輸入折扣")]
            [RegularExpression("[0-1][.]{0,1}[0-9]{0,1}[0-9]{0,1}", ErrorMessage = "請輸入0-1之間的數字，小數位數至多兩位")]
            public float Discount { get; set; }

        }
    public  class MetadataOrders
    {
        [DisplayName("訂單號碼")]
        public int OrderID { get; set; }
        [DisplayName("客戶編號")]
        public string CustomerID { get; set; }
        [DisplayName("員工編號")]
        public int EmployeeID { get; set; }
        [DisplayName("訂單日期")]
        [DataType(DataType.DateTime, ErrorMessage = "輸入日期有誤")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime OrderDate { get; set; }
        [DisplayName("要貨日期")]
        [DataType(DataType.DateTime, ErrorMessage = "輸入日期有誤")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> RequiredDate { get; set; }
        [DisplayName("送貨日期")]
        [DataType(DataType.DateTime, ErrorMessage = "輸入日期有誤")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ShippedDate { get; set; }
        [DisplayName("送貨方式")]
        [Required(ErrorMessage = "請輸入送貨方式")]
        public int ShipVia { get; set; }
        [DisplayName("運費")]
        [Range(0, double.MaxValue, ErrorMessage = "運費不可小於0")]
        public Nullable<decimal> Freight { get; set; }
        [DisplayName("收貨人")]
        [Required(ErrorMessage = "請輸入收貨人")]
        [StringLength(40, ErrorMessage = "收貨人最長40個字")]
        public string ShipName { get; set; }
        [DisplayName("送貨地址")]
        [Required(ErrorMessage = "請輸入送貨地址")]
        [StringLength(60, ErrorMessage = "送貨地址最長60個字")]
        public string ShipAddress { get; set; }
        [DisplayName("送貨郵遞區號")]
        [StringLength(10, ErrorMessage = "郵遞區號最長10個字")]
        public string ShipPostalCode { get; set; }

    }
    public  class MetadataProducts
    {
        [DisplayName("產品編號")]
        [Required(ErrorMessage = "請輸入產品編號")]
        public int ProductID { get; set; }
        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "請輸入產品名稱")]
        [StringLength(40, ErrorMessage = "長度最長40字")]
        public string ProductName { get; set; }
        [DisplayName("供應商編號")]
        [Required(ErrorMessage = "請輸入供應商編號")]
        public int SupplierID { get; set; }
        [DisplayName("產品類別")]
        [Required(ErrorMessage = "請輸入產品類別")]
        public int CategoryID { get; set; }
        [DisplayName("產品單位")]
        [Required(ErrorMessage = "請輸入產品單位")]
        [StringLength(20, ErrorMessage = "長度最長20字")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("產品單價")]
        [Required(ErrorMessage = "請輸入單價")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "單價不可小於0")]
        public decimal UnitPrice { get; set; }
        [DisplayName("庫存量")]
        [Required(ErrorMessage = "請輸入庫存量")]
        [Range(0, int.MaxValue, ErrorMessage = "庫存量不可小於0")]
        public short UnitsInStock { get; set; }
        [DisplayName("已採購量")]
        [Required(ErrorMessage = "請輸入已訂購量")]
        [Range(0, int.MaxValue, ErrorMessage = "已訂購量不可小於0")]
        public short UnitsOnOrder { get; set; }
        [DisplayName("安全存量")]
        [Required(ErrorMessage = "請輸入安全存量")]
        [Range(0, int.MaxValue, ErrorMessage = "安全存量不可小於0")]
        public short ReorderLevel { get; set; }
        [DisplayName("是否下架")]
        [Required(ErrorMessage = "請選擇是否繼續銷售")]
        [DefaultValue(false)]
        public bool Discontinued { get; set; }

    }
    public  class MetadataShippers
    {
        [DisplayName("貨運公司編號")]
        public int ShipperID { get; set; }
        [DisplayName("貨運公司名稱")]
        [Required(ErrorMessage = "請輸入貨運公司名稱")]
        [StringLength(40, ErrorMessage = "長度最長40字")]
        public string CompanyName { get; set; }
        [DisplayName("電話")]
        [Required(ErrorMessage = "請輸入電話")]
        [StringLength(24, ErrorMessage = "長度最長24字")]
        public string Phone { get; set; }

    }
    public  class MetadataSuppliers
    {
        [DisplayName("供應商編號")]
        public int SupplierID { get; set; }
        [DisplayName("供應商名稱")]
        [Required(ErrorMessage = "請輸入供應商名稱")]
        [StringLength(40, ErrorMessage = "長度最長40字")]
        public string CompanyName { get; set; }
        [DisplayName("聯絡人")]
        [Required(ErrorMessage = "請輸入聯絡人")]
        [StringLength(30, ErrorMessage = "長度最長30字")]
        public string ContactName { get; set; }
        [DisplayName("聯絡人職稱")]
        [Required(ErrorMessage = "請輸入聯絡人職稱")]
        [StringLength(30, ErrorMessage = "長度最長30字")]
        public string ContactTitle { get; set; }
        [DisplayName("地址")]
        [Required(ErrorMessage = "請輸入地址")]
        [StringLength(60, ErrorMessage = "長度最長60字")]
        public string Address { get; set; }
        [DisplayName("郵遞區號")]
        [StringLength(10, ErrorMessage = "長度最長10字")]
        public string PostalCode { get; set; }
        [DisplayName("電話")]
        [Required(ErrorMessage = "請輸入電話")]
        [StringLength(24, ErrorMessage = "長度最長24字")]
        public string Phone { get; set; }
        [DisplayName("傳真電話")]
        [StringLength(24, ErrorMessage = "長度最長24字")]
        public string Fax { get; set; }

    }

    public class CheckCustomerID:ValidationAttribute
    {
        NorthwindEntities db = new NorthwindEntities();

        public CheckCustomerID() {
            ErrorMessage = "帳號重複";
        }

        public override bool IsValid(object value)
        {
            var result = db.Customers.Where(c => c.CustomerID == value.ToString()).FirstOrDefault();
            if (result == null)
                return true;
            return false;
        }
    }
}