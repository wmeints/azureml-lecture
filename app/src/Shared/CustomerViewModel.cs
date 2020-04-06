namespace CustomerChurn.Shared
{
    public class CustomerViewModel
    {
        public string Id { get; set; }

        public string Gender { get; set; }

        public bool SeniorCitizen { get; set; }

        public bool Partner { get; set; }

        public bool Dependents { get; set; }

        public int Tenure { get; set; }

        public string PhoneService { get; set; }

        public string MultipleLines { get; set; }

        public string InternetService { get; set; }
        
        public string OnlineSecurity { get; set; }

        public string OnlineBackup { get; set; }

        public string DeviceProtection { get; set; }

        public string TechSupport { get; set; }

        public string StreamingTV { get; set; }
        
        public string StreamingMovies { get; set; }

        public string Contract { get; set; }

        public bool PaperlessBilling { get; set; }

        public string PaymentMethod { get; set; }

        public decimal MonthlyCharges { get; set; }

        public decimal TotalCharges { get; set; }
    }
}