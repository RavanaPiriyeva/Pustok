using System.Collections.Generic;

namespace Pustok.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItemViewModel> BasketItems { get; set; } = new List<BasketItemViewModel>();
        public double TotalAmount { get; set; }
    }
}
