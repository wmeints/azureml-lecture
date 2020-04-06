using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerChurn.Server.Data
{
    public class Customer
    {
        [Column(TypeName="char(10)")]
        public string Id { get; set; }

        [Column(TypeName="varchar(6)")]
        public string Gender { get; set; }

        public bool SeniorCitizen { get; set; }

        public bool Partner { get; set; }

        public bool Dependents { get; set; }

        public int Tenure { get; set; }

        [Column(TypeName="varchar(13)")]
        public Tristate PhoneService { get; set; }

        [Column(TypeName="varchar(13)")]
        public Tristate MultipleLines { get; set; }

        [Column(TypeName="varchar(13)")]
        public ConnectionType InternetService { get; set; }
        
        [Column(TypeName="varchar(13)")]
        public Tristate OnlineSecurity { get; set; }

        [Column(TypeName="varchar(13)")]
        public Tristate OnlineBackup { get; set; }

        [Column(TypeName="varchar(13)")]
        public Tristate DeviceProtection { get; set; }

        [Column(TypeName="varchar(13)")]
        public Tristate TechSupport { get; set; }

        [Column(TypeName="varchar(13)")]
        public Tristate StreamingTV { get; set; }
        
        [Column(TypeName="varchar(13)")]
        public Tristate StreamingMovies { get; set; }

        [Column(TypeName="varchar(50)")]
        public ContractType Contract { get; set; }

        public bool PaperlessBilling { get; set; }

        public PaymentMethodType PaymentMethod { get; set; }

        [Column(TypeName="money")]
        public decimal MonthlyCharges { get; set; }

        [Column(TypeName="money")]
        public decimal TotalCharges { get; set; }
    }
}