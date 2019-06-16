using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class UsuarioConfiguracao
    {
        public static UsuarioConfiguracao GetInstanceFor(String Usuario)
        {
            return new UsuarioConfiguracao(Usuario);
        }
        public enum TipoNome {
            [Display(Name = "PrimeiroNome", ResourceType = typeof(Resources.Resource))]
            Primeiro = 0,
            [Display(Name = "PrimeiroSegundo", ResourceType = typeof(Resources.Resource))]
            PrimeiroSegundo  = 1,
            [Display(Name = "PrimeiroUltimo", ResourceType = typeof(Resources.Resource))]
            PrimeiroUltimo = 2,
            [Display(Name = "UltimoNome", ResourceType = typeof(Resources.Resource))]
            Ultimo = 3,
            [Display(Name = "Completo", ResourceType = typeof(Resources.Resource))]
            Completo = 4,
         }

        public UsuarioConfiguracao() { }

        public UsuarioConfiguracao(string Usuario)
        {
            ExibicaoNome = TipoNome.Primeiro;
            var exibicao = CookieUtil.GetCookie(SecurityUtil.Base64Encode(Usuario).Replace("=", "") + "ExibicaoNome");
            if (exibicao != null)
            {
                try
                {
                    ExibicaoNome = (TipoNome)Convert.ToInt32(exibicao);
                }
                catch (Exception e) { }
            }
        }

        [Range(0, 4, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ChosenSelectOne")]
        [Display(Name = "ExibirNomeComo", ResourceType = typeof(Resources.Resource))]
        public TipoNome ExibicaoNome { get; set; }

        public void SaveCookies(string usuario)
        {
            CookieUtil.SetCookie(SecurityUtil.Base64Encode(usuario).Replace("=","") + "ExibicaoNome", ""+((int)ExibicaoNome), DateTime.Now.AddYears(5));
        }


    }
}