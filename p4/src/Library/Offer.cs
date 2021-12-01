using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.Defense
{
    public class Offer
    {
        public DateTime EndDate { get; set; }

        public IReadOnlyCollection<IOfferItem> Items
        {
            get
            {
                return new ReadOnlyCollection<IOfferItem>(this.items);
            }
        }

        public double Total
        {
            get
            {
                double result = 0;
                foreach (OfferItem item in this.items)
                {
                    result = result + item.SubTotal;
                }

                return result;
            }
        }

        private IList<IOfferItem> items = new List<IOfferItem>();

        public Offer(DateTime endDate)
        {
            this.EndDate = endDate;
        }

        public IOfferItem AddItem(Residue Residue, int quantity, int price)
        {
            IOfferItem item = new OfferItem(Residue, quantity, price);
            this.items.Add(item);
            return item;
        }

        public void RemoveItem(IOfferItem item)
        {
            this.items.Remove(item);
        }

        public IOfferItem AddDiscount(int amount)
        {
            string code = "No entiendo porque esta esto aca si en los casos de testeo no importa";
            IOfferItem item = new PromoCode(code,amount);
            this.items.Add(item);
            return item;
        }
    }
}