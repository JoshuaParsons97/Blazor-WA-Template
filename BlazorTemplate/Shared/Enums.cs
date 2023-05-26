namespace BlazorTemplate.Shared
{
    public class Enums
    {
        public enum ToastLevel
        {
            Info,
            Success,
            Warning,
            Error
        }

        public enum AccountSection
        {
            NotSet = -1,
            Orders,
            Addresses,
            Wishlists,
            AccountDetails
        }

        public enum UserRole
        {
            Unknown,
            Developer,
            OrderManager,
            ProductManager,
            ClientManager,
            DepartmentManager,
            SupplierManager,
            AccountingManager
        }

        public enum AccessType
        {
            Unknown,
            Edit,
            ReadOnly
        }

        public enum AddressType
        {
            Unknown,
            Residential,
            Business
        }

        public enum CompanyType
        {
            Unknown,
            Owner,
            Supplier
        }

        public enum ContactType
        {
            Unknown,
            Email,
            WorkPhone,
            HomePhone,
            Cellphone
        }

        public enum Courier
        {
            Unknown,
            TheCourierGuy
        }

        public enum DataType
        {
            Unknown,
            Number,
            Text,
            Date
        }

        public enum DeliveryMethod
        {
            Unknown,
            Delivery,
            Collection
        }

        public enum OrderStatus
        {
            Unknown,
            Unfinalized,
            Paid,
            ReadyForCollection,
            Complete,
            Cancelled
        }

        public enum PaymentMethod
        {
            Unknown,
            ManualPayment,
            OnlinePayment
        }

        public enum PaymentProvider
        {
            Unknown,
            Paygate
        }

        public enum Province
        {
            Unknown,
            Gauteng,
            WesternCape,
            KwaZuluNatal,
            EasternCape,
            FreeState,
            Limpopo,
            Mpumalanga,
            NorthernCape,
            NorthWest
        }

        public enum RecurrencePeriod
        {
            Unknown,
            Weekly,
            Monthly,
            Yearly
        }

        public enum SaleCampaignType
        {
            Unknown,
            Recurring,
            StartAndEndDate
        }

        public enum LegalTextType
        {
            Unknown,
            Disclaimer,
            TermsAndConditions,
            PrivacyPolicy,
            ReturnsPolicy,
            CookiePolicy
        }

        public enum NotificationType
        {
            Unknown,
            Error,
            Success,
            Info
        }

        public enum EmailTemplate
        {
            Unknown,
            AccountConfirmation,
            OrderConfirmation,
            PasswordRecovery,
            Contact
        }
    }
}
