using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("GastoModel")]
public class GastoModel
{
    [Key]
    public int Id { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }    
    public int idPessoa { get; set; }
    
}
