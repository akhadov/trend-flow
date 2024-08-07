using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.CreateProduct;
public sealed record CreateProductRequest(
    string Name,
    string Description,
    string ImagePath);
