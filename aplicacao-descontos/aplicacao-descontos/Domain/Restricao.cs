using System.ComponentModel.DataAnnotations;

namespace aplicacaodescontos.Domain
{
    public class Restricao
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }        
        public int AssociadoId { get; set; }

    }
}
