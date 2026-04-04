using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage = "La propiedad placa es requeridad")]
        [RegularExpression(@"[A-Za-z]{3}-[0-9]{3}", ErrorMessage = "El fromato de la placa debe ser ###-ABC")]

        public string Placa { get; set; }
        [Required(ErrorMessage = "La propiedad color es requeridad")]
        [StringLength(40, ErrorMessage = "La propiedad color debe ser mayor a 4 caracteres y menos de 40", MinimumLength = 4)]
        public string Color { get; set; }
        [Required(ErrorMessage = "La propiedad año es requeridad")]
        [RegularExpression(@"(19|20)\d\d", ErrorMessage = "El formato del año no es valido")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "La propiedad precio es requeridad")]
        public Decimal Precio { get; set; }
        [Required(ErrorMessage = "La propiedad correo es requeridad")]
        [EmailAddress]
        public string CorreoPropietario { get; set; }
        [Required(ErrorMessage = "La propiedad telefono es requerida")]
        [Phone]
        public string TelefonoPropietario { get; set; }

    }
    public class VehiculoRequest : VehiculoBase
    {
        public Guid IdModelo { get; set; }
    }

    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
    }
    public class VehiculoDetalle : VehiculoResponse
    {
        public bool RevisionValida { get; set; }
        public bool RegistroValido { get; set; }
    }
}
