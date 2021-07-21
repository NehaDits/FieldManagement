using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Ref1Navigation = new HashSet<Staff>();
            Ref2Navigation = new HashSet<Staff>();
            Ref3Navigation = new HashSet<Staff>();
            Ref4Navigation = new HashSet<Staff>();
            Ref5Navigation = new HashSet<Lead>();
            Ref6Navigation = new HashSet<Lead>();
            Ref7Navigation = new HashSet<Lead>();
            Ref8Navigation = new HashSet<LeadContact>();
            Ref9Navigation = new HashSet<LeadContact>();
            Ref10Navigation = new HashSet<LeadContact>();
            Ref11Navigation = new HashSet<Notes>();
            Ref12Navigation = new HashSet<Notes>();
            Ref13Navigation = new HashSet<Notes>();
            Ref14Navigation = new HashSet<LeadCall>();
            Ref15Navigation = new HashSet<ApplicationUser>();
            Ref16Navigation = new HashSet<ApplicationUser>();
            Ref17Navigation = new HashSet<Order>();
            Ref18Navigation = new HashSet<Order>();
            Ref19Navigation = new HashSet<Order>();
            Ref20Navigation = new HashSet<Order>();
            Ref21Navigation = new HashSet<Quotation>();
            Ref22Navigation = new HashSet<Quotation>();
            Ref23Navigation = new HashSet<JobOrderRequirement>();
            Ref24Navigation = new HashSet<JobOrderRequirement>();
            Ref25Navigation = new HashSet<Estimation>();
            Ref26Navigation = new HashSet<Estimation>();
            Ref36Navigation = new HashSet<Estimation>();
            Ref27Navigation = new HashSet<OrderTransaction>();
            Ref28Navigation = new HashSet<OrderTransaction>();
            Ref29Navigation = new HashSet<OrderTransaction>();
            Ref30Navigation = new HashSet<Vendor>();
            Ref31Navigation = new HashSet<Vendor>();
            Ref32Navigation = new HashSet<Vendor>();
            Ref33Navigation = new HashSet<ProductsIssued>();
            Ref34Navigation = new HashSet<ProductsIssued>();
            Ref35Navigation = new HashSet<ProductsIssued>();
            Ref37Navigation = new HashSet<EstimationDetail>();
            Ref38Navigation = new HashSet<EstimationDetail>();
            Ref39Navigation = new HashSet<EstimationDetail>();
            Ref40Navigation = new HashSet<Feedback>();
            Ref41Navigation = new HashSet<Feedback>();
            Ref42Navigation = new HashSet<Feedback>();
            Ref43Navigation = new HashSet<Maintenance>();
            Ref44Navigation = new HashSet<Maintenance>();
            Ref45Navigation = new HashSet<Maintenance>();
            Ref46Navigation = new HashSet<Quotation>();
            Ref47Navigation = new HashSet<JobOrderRequirement>();
            Ref48Navigation = new HashSet<OrderDetail>();
            Ref49Navigation = new HashSet<OrderDetail>();
            Ref50Navigation = new HashSet<OrderDetail>();
            Ref51Navigation = new HashSet<Procurement>();
            Ref52Navigation = new HashSet<Procurement>();
            Ref53Navigation = new HashSet<Procurement>();
            Ref54Navigation = new HashSet<Product>();
            Ref55Navigation = new HashSet<Product>();
            Ref56Navigation = new HashSet<Product>();
            Ref57Navigation = new HashSet<ProductMaster>();
            Ref58Navigation = new HashSet<ProductMaster>();
            Ref59Navigation = new HashSet<ProductMaster>();
            Ref60Navigation = new HashSet<ServiceProviderLocation>();
            Ref61Navigation = new HashSet<ServiceProviderLocation>();
            Ref62Navigation = new HashSet<ServiceProviderLocation>();
            Ref63Navigation = new HashSet<GlobalCodeCategory>();
            Ref64Navigation = new HashSet<GlobalCodeCategory>();
            Ref65Navigation = new HashSet<GlobalCodeCategory>();
            Ref66Navigation = new HashSet<GlobalCode>();
            Ref67Navigation = new HashSet<GlobalCode>();
            Ref68Navigation = new HashSet<GlobalCode>();
            Ref69Navigation = new HashSet<Client>();
            Ref70Navigation = new HashSet<Client>();
            Ref71Navigation = new HashSet<Client>();
            Ref72Navigation = new HashSet<City>();
            Ref73Navigation = new HashSet<City>();
            Ref74Navigation = new HashSet<City>();
            Ref75Navigation = new HashSet<State>();
            Ref76Navigation = new HashSet<State>();
            Ref77Navigation = new HashSet<State>();
            Ref78Navigation = new HashSet<Country>();
            Ref79Navigation = new HashSet<Country>();
            Ref80Navigation = new HashSet<Country>();
            Ref81Navigation = new HashSet<ClientContact>();
            Ref82Navigation = new HashSet<ClientContact>();
            Ref83Navigation = new HashSet<ClientContact>();
            Ref84Navigation = new HashSet<ContactDetail>();
            Ref85Navigation = new HashSet<ContactDetail>();
            Ref86Navigation = new HashSet<ContactDetail>();
            Ref87Navigation = new HashSet<JobOrder>();
            Ref88Navigation = new HashSet<JobOrder>();
            Ref89Navigation = new HashSet<JobOrder>();
            Ref90Navigation = new HashSet<VendorProducts>();
            Ref91Navigation = new HashSet<VendorProducts>();
            Ref92Navigation = new HashSet<VendorProducts>();
            Ref93Navigation = new HashSet<AddressDetail>();
            Ref94Navigation = new HashSet<AddressDetail>();
            Ref95Navigation = new HashSet<AddressDetail>();
        }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string DeletedBy { get; set; }
        public ApplicationUser RefDeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CreatedBy { get; set; }
        public ApplicationUser RefCreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Staff> Ref1Navigation { get; set; }
        public ICollection<Staff> Ref2Navigation { get; set; }
        public ICollection<Staff> Ref3Navigation { get; set; }
        public ICollection<Staff> Ref4Navigation { get; set; }
        public ICollection<Lead> Ref5Navigation { get; set; }
        public ICollection<Lead> Ref6Navigation { get; set; }
        public ICollection<Lead> Ref7Navigation { get; set; }
        public ICollection<LeadContact> Ref8Navigation { get; set; }
        public ICollection<LeadContact> Ref9Navigation { get; set; }
        public ICollection<LeadContact> Ref10Navigation { get; set; }
        public ICollection<Notes> Ref11Navigation { get; set; }
        public ICollection<Notes> Ref12Navigation { get; set; }
        public ICollection<Notes> Ref13Navigation { get; set; }
        public ICollection<LeadCall> Ref14Navigation { get; set; }
        public ICollection<ApplicationUser> Ref15Navigation { get; set; }
        public ICollection<ApplicationUser> Ref16Navigation { get; set; }
        public ICollection<Order> Ref17Navigation { get; set; }
        public ICollection<Order> Ref18Navigation { get; set; }
        public ICollection<Order> Ref19Navigation { get; set; }
        public ICollection<Order> Ref20Navigation { get; set; }
        public ICollection<Quotation> Ref21Navigation { get; set; }
        public ICollection<Quotation> Ref22Navigation { get; set; }
        public ICollection<JobOrderRequirement> Ref23Navigation { get; set; }
        public ICollection<JobOrderRequirement> Ref24Navigation { get; set; }
        public ICollection<Estimation> Ref25Navigation { get; set; }
        public ICollection<Estimation> Ref26Navigation { get; set; }
        public ICollection<OrderTransaction> Ref27Navigation { get; set; }
        public ICollection<OrderTransaction> Ref28Navigation { get; set; }
        public ICollection<OrderTransaction> Ref29Navigation { get; set; }
        public ICollection<Vendor> Ref30Navigation { get; set; }
        public ICollection<Vendor> Ref31Navigation { get; set; }
        public ICollection<Vendor> Ref32Navigation { get; set; }
        public ICollection<ProductsIssued> Ref33Navigation { get; set; }
        public ICollection<ProductsIssued> Ref34Navigation { get; set; }
        public ICollection<ProductsIssued> Ref35Navigation { get; set; }
        public ICollection<Estimation> Ref36Navigation { get; set; }
        public ICollection<EstimationDetail> Ref37Navigation { get; set; }
        public ICollection<EstimationDetail> Ref38Navigation { get; set; }
        public ICollection<EstimationDetail> Ref39Navigation { get; set; }
        public ICollection<Feedback> Ref40Navigation { get; set; }
        public ICollection<Feedback> Ref41Navigation { get; set; }
        public ICollection<Feedback> Ref42Navigation { get; set; }
        public ICollection<Maintenance> Ref43Navigation { get; set; }
        public ICollection<Maintenance> Ref44Navigation { get; set; }
        public ICollection<Maintenance> Ref45Navigation { get; set; }
        public ICollection<Quotation> Ref46Navigation { get; set; }
        public ICollection<JobOrderRequirement> Ref47Navigation { get; set; }
        public ICollection<OrderDetail> Ref48Navigation { get; set; }
        public ICollection<OrderDetail> Ref49Navigation { get; set; }
        public ICollection<OrderDetail> Ref50Navigation { get; set; }
        public ICollection<Procurement> Ref51Navigation { get; set; }
        public ICollection<Procurement> Ref52Navigation { get; set; }
        public ICollection<Procurement> Ref53Navigation { get; set; }
        public ICollection<Product> Ref54Navigation { get; set; }
        public ICollection<Product> Ref55Navigation { get; set; }
        public ICollection<Product> Ref56Navigation { get; set; }
        public ICollection<ProductMaster> Ref57Navigation { get; set; }
        public ICollection<ProductMaster> Ref58Navigation { get; set; }
        public ICollection<ProductMaster> Ref59Navigation { get; set; }
        public ICollection<ServiceProviderLocation> Ref60Navigation { get; set; }
        public ICollection<ServiceProviderLocation> Ref61Navigation { get; set; }
        public ICollection<ServiceProviderLocation> Ref62Navigation { get; set; }
        public ICollection<GlobalCodeCategory> Ref63Navigation { get; set; }
        public ICollection<GlobalCodeCategory> Ref64Navigation { get; set; }
        public ICollection<GlobalCodeCategory> Ref65Navigation { get; set; }
        public ICollection<GlobalCode> Ref66Navigation { get; set; }
        public ICollection<GlobalCode> Ref67Navigation { get; set; }
        public ICollection<GlobalCode> Ref68Navigation { get; set; }
        public ICollection<Client> Ref69Navigation { get; set; }
        public ICollection<Client> Ref70Navigation { get; set; }
        public ICollection<Client> Ref71Navigation { get; set; }
        public ICollection<City> Ref72Navigation { get; set; }
        public ICollection<City> Ref73Navigation { get; set; }
        public ICollection<City> Ref74Navigation { get; set; }
        public ICollection<State> Ref75Navigation { get; set; }
        public ICollection<State> Ref76Navigation { get; set; }
        public ICollection<State> Ref77Navigation { get; set; }
        public ICollection<Country> Ref78Navigation { get; set; }
        public ICollection<Country> Ref79Navigation { get; set; }
        public ICollection<Country> Ref80Navigation { get; set; }
        public ICollection<ClientContact> Ref81Navigation { get; set; }
        public ICollection<ClientContact> Ref82Navigation { get; set; }
        public ICollection<ClientContact> Ref83Navigation { get; set; }
        public ICollection<ContactDetail> Ref84Navigation { get; set; }
        public ICollection<ContactDetail> Ref85Navigation { get; set; }
        public ICollection<ContactDetail> Ref86Navigation { get; set; }
        public ICollection<JobOrder> Ref87Navigation { get; set; }
        public ICollection<JobOrder> Ref88Navigation { get; set; }
        public ICollection<JobOrder> Ref89Navigation { get; set; }
        public ICollection<VendorProducts> Ref90Navigation { get; set; }
        public ICollection<VendorProducts> Ref91Navigation { get; set; }
        public ICollection<VendorProducts> Ref92Navigation { get; set; }
        public ICollection<AddressDetail> Ref93Navigation { get; set; }
        public ICollection<AddressDetail> Ref94Navigation { get; set; }
        public ICollection<AddressDetail> Ref95Navigation { get; set; }
    }
}
