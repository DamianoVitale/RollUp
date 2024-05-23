using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollUp
{
    public static class RollUpMethod
    {
        public static RollUpResult RollUpControlVariant(List<Products> p)
        {
            var filtered = p.Where(p => p.Price.HasValue).ToList();
            var result = new RollUpResult();

            var groupedByVariant = filtered
                .GroupBy(p => p.Variant)
                .Select(g =>
                {
                    var selected = g.OrderBy(p => p.Price).First();
                    var discarded = g.Where(item => item != selected).ToList();
                    result.Discarded.AddRange(discarded);
                    return selected;
                })
                .ToList();

            result.Selected = groupedByVariant;

            return result;
        }

        public static RollUpResult RollUpControlProduct(List<Products> p)
        {
            var variantResult = RollUpControlVariant(p);
            var result = new RollUpResult();

            var groupedByProduct = variantResult.Selected
                .GroupBy(p => p.Product)
                .Select(g =>
                {
                    var selected = g.OrderBy(p => p.Price).First();
                    var discarded = g.Where(item => item != selected).ToList();
                    result.Discarded.AddRange(discarded);
                    return selected;
                })
                .ToList();

            result.Selected = groupedByProduct;
            result.Discarded.AddRange(variantResult.Discarded);

            return result;
        }
    }
}
