using System.ComponentModel.DataAnnotations.Schema;

namespace Skinet.Core.Entities;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public string Name { get; set; }
}