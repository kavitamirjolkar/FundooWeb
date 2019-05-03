

namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
   public class LabelModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Label { get; set; }
    }
}
