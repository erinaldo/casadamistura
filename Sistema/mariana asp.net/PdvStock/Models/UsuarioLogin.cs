using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PdvStock.Models
{
    public class UsuarioLogin
    {
        [Display(Name = "Usuario", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "OCampoObrigatorio", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Usuario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "OCampoObrigatorio", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Senha { get; set; }

        [Display(Name = "Lembreme", ResourceType = typeof(Resources.Resource))]
        public bool RememberMe { get; set; }
    }
          
}
