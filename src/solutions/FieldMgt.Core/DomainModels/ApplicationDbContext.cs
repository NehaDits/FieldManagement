using FluentValidation.WebApi;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadContact> LeadContacts { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<LeadCall> LeadCalls { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<ServiceProviderLocation> ServiceProviderLocations { get; set; }
        public DbSet<ProductsIssued> ProductsIssued { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<AddressDetail> AddressDetails { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ProductMaster> ProductsMaster { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Procurement> Procurements { get; set; }
        public DbSet<ProcurementProduct> ProcurementProducts { get; set; }
        public DbSet<Estimation> Estimations { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<JobOrderRequirement> JobOrderRequirements { get; set; }
        public DbSet<EstimationDetail> EstimationDetails { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<OrderTransaction> OrderTransactions { get; set; }
        public DbSet<GlobalCode> GlobalCodes { get; set; }
        public DbSet<GlobalCodeCategory> GlobalCodeCategories { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<JobOrder> JobOrders { get; set; }
        public DbSet<OrderImplementationDetail> OrderImplementationDetails { get; set; }
        public DbSet<VendorProducts> VendorProducts { get; set; }
        protected virtual void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<ApplicationUser>().HasKey(m => m.Id);
            modelBuilder.Entity<Lead>().Property(s => s.LeadId).HasDatabaseGeneratedOption
(DatabaseGeneratedOption.Identity); ;
            modelBuilder.Entity<Staff>().Property(s => s.StaffId).HasDatabaseGeneratedOption
(DatabaseGeneratedOption.Identity); ;
            modelBuilder.Entity<LeadContact>().Property(s =>  s.LeadContactId ).HasDatabaseGeneratedOption
                (DatabaseGeneratedOption.Identity); ;
            modelBuilder.Entity<GlobalCode>().Property(s => s.GlobalCodeId).HasDatabaseGeneratedOption
                (DatabaseGeneratedOption.Identity); ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>(act =>
            {
                act.HasOne(field => field.StaffDesignation)
               .WithMany(fk => fk.Staff1Navigation)
               .HasForeignKey(fk => fk.Designation)
               .HasConstraintName("Designation_FK");

                act.HasOne(field => field.StaffGender)
               .WithMany(fk => fk.Staff2Navigation)
               .HasForeignKey(fk => fk.Gender)
               .HasConstraintName("StaffGender_FK");

                act.HasOne(field => field.StaffUserId)
                .WithMany(fk => fk.Ref1Navigation)
                .HasForeignKey(fk => fk.UserId)
                .HasConstraintName("UserId_FK");

                act.HasOne(field => field.StaffCreatedBy)
               .WithMany(fk => fk.Ref2Navigation)
               .HasForeignKey(fk => fk.CreatedBy)
               .HasConstraintName("Created_FK");

                act.HasOne(field => field.StaffModifiedBy)
                .WithMany(fk => fk.Ref3Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("Modified_FK");

                act.HasOne(field => field.StaffDeletedBy)
                .WithMany(fk => fk.Ref4Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("Deleted_FK");


                act.HasOne(field => field.StaffPermaAddress)
                .WithMany(fk => fk.StaffAddress1Id)
                .HasForeignKey(fk => fk.PermanentAddressId)
                .HasConstraintName("PermanentAddress_FK");

                act.HasOne(field => field.StaffCorresAddress)
                .WithMany(fk => fk.StaffAddress2Id)
                .HasForeignKey(fk => fk.CorrespondenceAddressId)
                .HasConstraintName("CorrespondenceAddress_FK");
            });
            modelBuilder.Entity<Lead>(act =>
            {
                act.HasOne(field => field.RefStage)
                .WithMany(fk => fk.Lead1Navigation)
                .HasForeignKey(fk => fk.LeadStatus)
                .HasConstraintName("LeadStatus_FK");

                act.HasOne(field => field.RefSource)
               .WithMany(fk => fk.Lead2Navigation)
               .HasForeignKey(fk => fk.LeadSource)
               .HasConstraintName("LeadSource_FK");

                act.HasOne(field => field.RefStatus)
               .WithMany(fk => fk.Lead3Navigation)
               .HasForeignKey(fk => fk.LeadStage)
               .HasConstraintName("LeadStage_FK");

                act.HasOne(field => field.LeadCreatedBy)
               .WithMany(fk => fk.Ref5Navigation)
               .HasForeignKey(fk => fk.CreatedBy)
               .HasConstraintName("LCreatedBy_FK");

                act.HasOne(field => field.LeadModifiedBy)
                .WithMany(fk => fk.Ref6Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("LModifiedBy_FK");

                act.HasOne(field => field.LeadDeletedBy)
                .WithMany(fk => fk.Ref7Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("LDeletedBy_FK");


                act.HasOne(field => field.LeadAddress)
                .WithMany(fk => fk.LeadAddress1Id)
                .HasForeignKey(fk => fk.PermanentAddressId)
                .HasConstraintName("LPermaAddress_FK");

                act.HasOne(field => field.LeadBillingAddress)
                .WithMany(fk => fk.LeadAddress2Id)
                .HasForeignKey(fk => fk.BillingAddressId)
                .HasConstraintName("LBillingAddress_FK");
            });
            modelBuilder.Entity<LeadContact>(act =>
            {                
                act.HasOne(field => field.RefGender)
                .WithMany(fk => fk.LeadContact1Navigation)
                .HasForeignKey(fk => fk.Gender)
                .HasConstraintName("LCGender_FK");

                act.HasOne(field => field.LeadContactCreatedBy)
               .WithMany(fk => fk.Ref8Navigation)
               .HasForeignKey(fk => fk.CreatedBy)
               .HasConstraintName("LCCreatedBy_FK");

                act.HasOne(field => field.LeadContactModifiedBy)
                .WithMany(fk => fk.Ref9Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("LCModifiedBy_FK");

                act.HasOne(field => field.LeadContactDeletedBy)
                .WithMany(fk => fk.Ref10Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("LCDeletedBy_FK");
            });
            modelBuilder.Entity<Notes>(act =>
            {
                act.HasOne(field => field.NotesCreatedBy)
                .WithMany(fk => fk.Ref11Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("NotesCreatedBy_FK");

                act.HasOne(field => field.NotesModifiedBy)
               .WithMany(fk => fk.Ref12Navigation)
               .HasForeignKey(fk => fk.ModifiedBy)
               .HasConstraintName("NotesModifiedBy_FK");

                act.HasOne(field => field.NotesDeletedBy)
                .WithMany(fk => fk.Ref13Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("NotesDeletedTo_FK");
            });
            modelBuilder.Entity<LeadCall>(act =>
            {
                act.HasOne(field => field.LeadCalledBy)
                .WithMany(fk => fk.Ref14Navigation)
                .HasForeignKey(fk => fk.CalledBy)
                .HasConstraintName("LCCalledBy_FK");

                act.HasOne(field => field.RefLeadCallStatus)
               .WithMany(fk => fk.LeadCall1Navigation)
               .HasForeignKey(fk => fk.CallStatus)
               .HasConstraintName("LCStatus_FK");

                act.HasOne(field => field.RefCallLeadId)
                .WithMany(fk => fk.Ref2LeadId)
                .HasForeignKey(fk => fk.LeadId)
                .HasConstraintName("LCLeadId_FK");
            });
            modelBuilder.Entity<ApplicationUser>(act =>
            {
                act.HasOne(field => field.RefDeletedBy)
                .WithMany(fk => fk.Ref15Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("UserDeletedBy_FK");

                act.HasOne(field => field.RefCreatedBy)
                .WithMany(fk => fk.Ref16Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("UserCreatedBy_FK");
            });
            modelBuilder.Entity<Order>(act =>
            {
                act.HasOne(field => field.OrderCreatedBy)
                .WithMany(fk => fk.Ref17Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("OrderCreatedBy_FK");

                act.HasOne(field => field.OrderModifiedBy)
                .WithMany(fk => fk.Ref18Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("OrderModifiedBy_FK");

                act.HasOne(field => field.OrderDeletedBy)
                .WithMany(fk => fk.Ref19Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("OrderDeletedBy_FK");

                act.HasOne(field => field.OrderAssignedTo)
                .WithMany(fk => fk.Ref20Navigation)
                .HasForeignKey(fk => fk.AssignedTo)
                .HasConstraintName("OrderAssignedTo_FK");

                act.HasOne(field => field.OrderPaymentStatus)
                .WithMany(fk => fk.OPStatus)
                .HasForeignKey(fk => fk.PaymentStatus)
                .HasConstraintName("OrderPaymentStatus_FK");

                act.HasOne(field => field.OrderCompletionStatus)
                .WithMany(fk => fk.OrdersStatus)
                .HasForeignKey(fk => fk.OrderStatus)
                .HasConstraintName("OrderStatus_FK");

                act.HasOne(field => field.OrderAddress)
                .WithMany(fk => fk.OrderAddress1Id)
                .HasForeignKey(fk => fk.PermanentAddressId)
                .HasConstraintName("OrderPermaAddress_FK");

                act.HasOne(field => field.OrderBillingAddress)
                .WithMany(fk => fk.OrderAddress2Id)
                .HasForeignKey(fk => fk.BillingAddressId)
                .HasConstraintName("OrderBillingAddress_FK");
            });
            modelBuilder.Entity<Quotation>(act =>
            {
                act.HasOne(field => field.NegotitationCreatedBy)
                .WithMany(fk => fk.Ref21Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("QuotationCreatedBy_FK");

                act.HasOne(field => field.NegotitationModifiedBy)
                .WithMany(fk => fk.Ref22Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("QuotationModifiedBy_FK");

                act.HasOne(field => field.NegotitationDeletedBy)
                .WithMany(fk => fk.Ref46Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("QuotationDeletedBy_FK");
            });
            modelBuilder.Entity<JobOrderRequirement>(act =>
            {
                act.HasOne(field => field.RequirementCreatedBy)
                .WithMany(fk => fk.Ref23Navigation)
                .HasForeignKey(fk => fk.RequirementGatheredBy)
                .HasConstraintName("RequirementCreatedBy_FK");

                act.HasOne(field => field.RequirementModifiedBy)
                .WithMany(fk => fk.Ref24Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("RequirementModifiedBy_FK");

                act.HasOne(field => field.RequirementDeletedBy)
                .WithMany(fk => fk.Ref47Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("RequirementDeletedBy_FK");
            });
            modelBuilder.Entity<Estimation>(act =>
            {
                act.HasOne(field => field.EstimationCreatedBy)
                .WithMany(fk => fk.Ref25Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("EstimationCreatedBy_FK");

                act.HasOne(field => field.EstimationModifiedBy)
                .WithMany(fk => fk.Ref26Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("EstimationModifiedBy_FK");


                act.HasOne(field => field.EstimationDeletedBy)
                .WithMany(fk => fk.Ref36Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("EstimationDeletedBy_FK");
            });
            modelBuilder.Entity<EstimationDetail>(act =>
            {
                act.HasOne(field => field.EstimationDetailCreatedBy)
                .WithMany(fk => fk.Ref37Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("EstimationDetailCreatedBy_FK");

                act.HasOne(field => field.EstimationDetailModifiedBy)
                .WithMany(fk => fk.Ref38Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("EstimationDetailModifiedBy_FK");


                act.HasOne(field => field.EstimationDetailDeletedBy)
                .WithMany(fk => fk.Ref39Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("EstimationDetailDeletedBy_FK");
            });
            modelBuilder.Entity<Maintenance>(act =>
            {
                act.HasOne(field => field.MaintenanceCreatedBy)
                .WithMany(fk => fk.Ref43Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("MaintenanceCreatedBy_FK");

                act.HasOne(field => field.MaintenanceModifiedBy)
                .WithMany(fk => fk.Ref44Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("MaintenanceModifiedBy_FK");


                act.HasOne(field => field.MaintenanceDeletedBy)
                .WithMany(fk => fk.Ref45Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("MaintenanceDeletedBy_FK");

                act.HasOne(field => field.RefMaintenanceType)
                .WithMany(fk => fk.MaintenanceTypesRef)
                .HasForeignKey(fk => fk.MaintenanceType)
                .HasConstraintName("MaintenanceType_FK");
            });
            modelBuilder.Entity<Feedback>(act =>
            {
                act.HasOne(field => field.FeedBackCreatedBy)
                .WithMany(fk => fk.Ref40Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("FeedbackCreatedBy_FK");

                act.HasOne(field => field.FeedBackModifiedBy)
                .WithMany(fk => fk.Ref41Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("FeedbackModifiedBy_FK");


                act.HasOne(field => field.FeedBackDeletedBy)
                .WithMany(fk => fk.Ref42Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("FeedbackDeletedBy_FK");
            });
            modelBuilder.Entity<OrderDetail>(act =>
            {
                act.HasOne(field => field.OrderProductCreatedBy)
                .WithMany(fk => fk.Ref48Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("OPCreatedBy_FK");

                act.HasOne(field => field.OrderProductModifiedBy)
                .WithMany(fk => fk.Ref49Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("OPModifiedBy_FK");


                act.HasOne(field => field.OrderProductDeletedBy)
                .WithMany(fk => fk.Ref50Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("OPDeletedBy_FK");
            });
            modelBuilder.Entity<Procurement>(act =>
            {
                act.HasOne(field => field.ProcurementCreatedBy)
                .WithMany(fk => fk.Ref51Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("ProcurementCreatedBy_FK");

                act.HasOne(field => field.ProcurementModifiedBy)
                .WithMany(fk => fk.Ref52Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("ProcurementModifiedBy_FK");


                act.HasOne(field => field.ProcurementDeletedBy)
                .WithMany(fk => fk.Ref53Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("ProcurementDeletedBy_FK");
            });
            modelBuilder.Entity<OrderTransaction>(act =>
            {
                act.HasOne(field => field.OrderTransactionCreatedBy)
                .WithMany(fk => fk.Ref27Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("OrderTransactionCreatedBy_FK");

                act.HasOne(field => field.OrderTransactionModifiedBy)
                .WithMany(fk => fk.Ref28Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("OrderTransactionModifiedBy_FK");

                act.HasOne(field => field.OrderTransactionDeletedBy)
                .WithMany(fk => fk.Ref29Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("OrderTransactionDeletedBy_FK");
            });
            modelBuilder.Entity<Vendor>(act =>
            {
                act.HasOne(field => field.VendorCreatedBy)
                .WithMany(fk => fk.Ref30Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("VendorCreatedBy_FK");

                act.HasOne(field => field.VendorModifiedBy)
                .WithMany(fk => fk.Ref31Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("VendorModifiedBy_FK");

                act.HasOne(field => field.VendorDeletedBy)
                .WithMany(fk => fk.Ref32Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("VendorDeletedBy_FK");

                act.HasOne(field => field.VendorAddress)
                .WithMany(fk => fk.VendorAddress1Id)
                .HasForeignKey(fk => fk.PermanentAddressId)
                .HasConstraintName("VendorPermaAddress_FK");

                act.HasOne(field => field.VendorBillingAddress)
                .WithMany(fk => fk.VendorAddress2Id)
                .HasForeignKey(fk => fk.BillingAddressId)
                .HasConstraintName("VendorBillingAddress_FK");
            });
            modelBuilder.Entity<ProductsIssued>(act =>
            {
                act.HasOne(field => field.ProductIssuedBy)
                .WithMany(fk => fk.Ref33Navigation)
                .HasForeignKey(fk => fk.IssuedBy)
                .HasConstraintName("ProductIssuedBy_FK");

                act.HasOne(field => field.PIModifiedBy)
                .WithMany(fk => fk.Ref34Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("PIModifiedBy_FK");

                act.HasOne(field => field.PIDeletedBy)
                .WithMany(fk => fk.Ref35Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("PIdeletedBy_FK");
            });
            modelBuilder.Entity<ServiceProvider>(act =>
            {
                act.HasOne(field => field.ServiceProviderAddress)
                .WithMany(fk => fk.ServiceProviderAddress1Id)
                .HasForeignKey(fk => fk.PermanentAddressId)
                .HasConstraintName("SPPermaAddress_FK");

                act.HasOne(field => field.ServiceProviderBillingAddress)
                .WithMany(fk => fk.ServiceProviderAddress2Id)
                .HasForeignKey(fk => fk.BillingAddressId)
                .HasConstraintName("SPBillingAddress_FK");
            });
            modelBuilder.Entity<ServiceProviderLocation>(act =>
            {
                act.HasOne(field => field.ServiceProviderLocationAddress)
                .WithMany(fk => fk.ServiceProviderLocationAddress1Id)
                .HasForeignKey(fk => fk.PermanentAddressId)
                .HasConstraintName("SPLocationPermaAddress_FK");

                act.HasOne(field => field.ServiceProviderLocationBillingAddress)
                .WithMany(fk => fk.ServiceProviderLocationAddress2Id)
                .HasForeignKey(fk => fk.BillingAddressId)
                .HasConstraintName("SPLocationBillingAddress_FK");

                act.HasOne(field => field.SPLCreatedBy)
                .WithMany(fk => fk.Ref60Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("SPLCreatedBy_FK");

                act.HasOne(field => field.SPLModifiedBy)
                .WithMany(fk => fk.Ref61Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("SPLModifiedBy_FK");

                act.HasOne(field => field.SPLDeletedBy)
                .WithMany(fk => fk.Ref62Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("SPLDeleted_FK");            
        });
            modelBuilder.Entity<Product>(act =>
            {
                act.HasOne(field => field.ProductCreatedBy)
                .WithMany(fk => fk.Ref54Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("ProductCreatedBy_FK");

                act.HasOne(field => field.ProductModifiedBy)
                .WithMany(fk => fk.Ref55Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("ProductModifiedBy_FK");


                act.HasOne(field => field.ProductDeletedBy)
                .WithMany(fk => fk.Ref56Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("ProductDeletedBy_FK");
            });
            modelBuilder.Entity<ProductMaster>(act =>
            {
                act.HasOne(field => field.Category)
                .WithMany(fk => fk.ProductCategoryRef)
                .HasForeignKey(fk => fk.ProductCategory)
                .HasConstraintName("PMCategory_FK");

                act.HasOne(field => field.ProductMasterCreatedBy)
                .WithMany(fk => fk.Ref57Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("PMCreatedBy_FK");

                act.HasOne(field => field.ProductMasterModifiedBy)
                .WithMany(fk => fk.Ref58Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("PMModifiedBy_FK");

                act.HasOne(field => field.ProductMasterDeletedBy)
                .WithMany(fk => fk.Ref59Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("PMDeleted_FK");
            });
            modelBuilder.Entity<GlobalCodeCategory>(act =>
            {
                act.HasOne(field => field.GlobalCodeCategoryCreatedBy)
                .WithMany(fk => fk.Ref63Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("GlobalCodeCategoryCreatedBy_FK");

                act.HasOne(field => field.GlobalCodeCategoryModifiedBy)
                .WithMany(fk => fk.Ref64Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("GlobalCodeCategoryModifiedBy_FK");


                act.HasOne(field => field.GlobalCodeCategoryDeletedBy)
                .WithMany(fk => fk.Ref65Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("GlobalCodeCategoryDeletedBy_FK");
            });
            modelBuilder.Entity<GlobalCode>(act =>
            {
                act.HasOne(field => field.GlobalCodeCreatedBy)
                .WithMany(fk => fk.Ref66Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("GlobalCodeCreatedBy_FK");

                act.HasOne(field => field.GlobalCodeModifiedBy)
                .WithMany(fk => fk.Ref67Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("GlobalCodeModifiedBy_FK");


                act.HasOne(field => field.GlobalCodeDeletedBy)
                .WithMany(fk => fk.Ref68Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("GlobalCodeDeletedBy_FK");
            });
            modelBuilder.Entity<Client>(act =>
            {
                act.HasOne(field => field.ClientCreatedBy)
                .WithMany(fk => fk.Ref69Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("ClientCreatedBy_FK");

                act.HasOne(field => field.ClientModifiedBy)
                .WithMany(fk => fk.Ref70Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("ClientModifiedBy_FK");

                act.HasOne(field => field.ClientDeletedBy)
                .WithMany(fk => fk.Ref71Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("ClientDeletedBy_FK");

                act.HasOne(field => field.RefSource)
                .WithMany(fk => fk.ClientSourceRef)
                .HasForeignKey(fk => fk.ClientSource)
                .HasConstraintName("ClientSource_FK");
            });
            modelBuilder.Entity<City>(act =>
            {
                act.HasOne(field => field.CityCreatedBy)
                .WithMany(fk => fk.Ref72Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("CityCreatedBy_FK");

                act.HasOne(field => field.CityModifiedBy)
                .WithMany(fk => fk.Ref73Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("CityModifiedBy_FK");


                act.HasOne(field => field.CityDeletedBy)
                .WithMany(fk => fk.Ref74Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("CityDeletedBy_FK");
            });
            modelBuilder.Entity<State>(act =>
            {
                act.HasOne(field => field.StateCreatedBy)
                .WithMany(fk => fk.Ref75Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("StateCreatedBy_FK");

                act.HasOne(field => field.StateModifiedBy)
                .WithMany(fk => fk.Ref76Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("StateModifiedBy_FK");


                act.HasOne(field => field.StateDeletedBy)
                .WithMany(fk => fk.Ref77Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("StateDeletedBy_FK");
            });
            modelBuilder.Entity<Country>(act =>
            {
                act.HasOne(field => field.CountryCreatedBy)
                .WithMany(fk => fk.Ref78Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("CountryCreatedBy_FK");

                act.HasOne(field => field.CountryModifiedBy)
                .WithMany(fk => fk.Ref79Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("CountryModifiedBy_FK");


                act.HasOne(field => field.CountryDeletedBy)
                .WithMany(fk => fk.Ref80Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("CountryDeletedBy_FK");
            });
            modelBuilder.Entity<AddressDetail>(act =>
            { 
                act.HasOne(field => field.AddressCode)
                .WithMany(fk => fk.AddressTypeRef)
                .HasForeignKey(fk => fk.AddressType)
                .HasConstraintName("AddressTypeRef_FK");

                act.HasOne(field => field.AddressCreatedBy)
                .WithMany(fk => fk.Ref93Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("AddressCreatedBy_FK");

                act.HasOne(field => field.AddressModifiedBy)
                .WithMany(fk => fk.Ref94Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("AddressModifiedBy_FK");

                act.HasOne(field => field.AddressDeletedBy)
                .WithMany(fk => fk.Ref95Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("AddressDeletedBy_FK");
            });
            modelBuilder.Entity<ClientContact>(act =>
            {
                act.HasOne(field => field.ClientContactCreatedBy)
                .WithMany(fk => fk.Ref81Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("ClientContactCreatedBy_FK");

                act.HasOne(field => field.ClientContactModifiedBy)
                .WithMany(fk => fk.Ref82Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("ClientContactModifiedBy_FK");


                act.HasOne(field => field.ClientContactDeletedBy)
                .WithMany(fk => fk.Ref83Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("ClientContactDeletedBy_FK");

                act.HasOne(field => field.RefGender)
                .WithMany(fk => fk.ClientContactSourceRef)
                .HasForeignKey(fk => fk.Gender)
                .HasConstraintName("ClientContactGender_FK");
            });
            modelBuilder.Entity<ContactDetail>(act =>
            {
                act.HasOne(field => field.ContactDetailsCreatedBy)
                .WithMany(fk => fk.Ref84Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("ContactDetailCreatedBy_FK");

                act.HasOne(field => field.ContactDetailsModifiedBy)
                .WithMany(fk => fk.Ref85Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("ContactDetailModifiedBy_FK");

                act.HasOne(field => field.ContactDetailsDeletedBy)
                .WithMany(fk => fk.Ref86Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("ContactDetailDeletedBy_FK");
            });
            modelBuilder.Entity<JobOrder>(act =>
            {
                act.HasOne(field => field.JobOrderCreatedBy)
                .WithMany(fk => fk.Ref87Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("JobOrderCreatedBy_FK");

                act.HasOne(field => field.JobOrderModifiedBy)
                .WithMany(fk => fk.Ref88Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("JobOrderModifiedBy_FK");

                act.HasOne(field => field.JobOrderDeletedBy)
                .WithMany(fk => fk.Ref89Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("JobOrderDeletedBy_FK");
            });
            modelBuilder.Entity<VendorProducts>(act =>
            {
                act.HasOne(field => field.VPCreatedBy)
                .WithMany(fk => fk.Ref90Navigation)
                .HasForeignKey(fk => fk.CreatedBy)
                .HasConstraintName("VPCreatedBy_FK");

                act.HasOne(field => field.VPModifiedBy)
                .WithMany(fk => fk.Ref91Navigation)
                .HasForeignKey(fk => fk.ModifiedBy)
                .HasConstraintName("VPModifiedBy_FK");

                act.HasOne(field => field.VPDeletedBy)
                .WithMany(fk => fk.Ref92Navigation)
                .HasForeignKey(fk => fk.DeletedBy)
                .HasConstraintName("VPDeletedBy_FK");
            });
            modelBuilder.Entity<Notes>(act =>
            {
                act.HasOne(field => field.NoteType)
                .WithMany(fk => fk.NotesTypeRef)
                .HasForeignKey(fk => fk.NoteTypeId)
                .HasConstraintName("NoteTypeRef_FK");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}

