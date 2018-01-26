using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PHP.Models
{
    public class Cart
    {


        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Member member)
        {
            CartLine line = lineCollection
                .FirstOrDefault(m => m.Member.FormId == member.FormId);

            if (line == null)
            {
                lineCollection.Add(new CartLine{Member = member});
            }

                              
        }

        public virtual void RemoveLine(Member member) => 
            lineCollection.RemoveAll(l=>l.Member.FormId == member.FormId);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;

        public bool InTheCart(Member member)
        {
            CartLine line = lineCollection
                .FirstOrDefault(m => m.Member.FormId == member.FormId);
            return (line != null);
        }
        

        public class CartLine
        {
            public int CartLineId { get; set; }
            public Member Member { get; set; }
        }

    }


}
