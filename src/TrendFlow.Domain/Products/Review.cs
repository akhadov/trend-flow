using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendFlow.Domain.Common;
using TrendFlow.Domain.Users;

namespace TrendFlow.Domain.Products;

public class Review : BaseAuditableEntity
{
    public decimal Stars { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get;  set; } = string.Empty;

    public long UserId { get; set; }
    public User? User { get; set; }

    public long ProductId { get; set; }
    public Product? Product { get; set; }
}
